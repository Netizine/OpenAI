// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// Global configuration class for OpenAI settings.
    /// </summary>
    public static class OpenAIConfiguration
    {
        private static string apiKey;

        private static string organizationId;

        private static int maxNetworkRetries = SystemNetHttpClient.DefaultMaxNumberRetries;

        private static IOpenAIClient openAIClient;

        static OpenAIConfiguration()
        {
            OpenAIClientVersion = new AssemblyName(typeof(OpenAIConfiguration).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <remarks>
        /// You can also set the API key using the <c>OpenAI:ApiKey</c> key in
        /// <see cref="System.Configuration.ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(apiKey) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["OpenAI:ApiKey"]))
                {
                    apiKey = ConfigurationManager.AppSettings["OpenAI:ApiKey"];
                }

                return apiKey;
            }

            set
            {
                if (value != apiKey)
                {
                    OpenAIClient = null;
                }

                apiKey = value;
            }
        }

        /// <summary>
        /// Organization id passed to OpenAI.
        /// </summary>
        /// <remarks>
        /// You can also set the Organization ID using the <c>OpenAI:OrganizationId</c> key in
        /// <see cref="System.Configuration.ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string OrganizationId
        {
            get
            {
                if (string.IsNullOrEmpty(organizationId) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["OpenAI:OrganizationId"]))
                {
                    organizationId = ConfigurationManager.AppSettings["OpenAI:OrganizationId"];
                }

                return organizationId;
            }

            set => organizationId = value;
        }

        /// <summary>
        /// Gets or sets the settings used for deserializing JSON objects returned by OpenAI's API.
        /// It is highly recommended you do not change these settings, as doing so can produce
        /// unexpected results. If you do change these settings, make sure that
        /// <see cref="OpenAIObjectConverter"/> is among the converters,
        /// otherwise OpenAI will no longer be able to deserialize polymorphic resources
        /// represented by interfaces.
        /// </summary>
        public static JsonSerializerSettings SerializerSettings { get; set; } = DefaultSerializerSettings();

        /// <summary>
        /// Gets or sets the maximum number of times that the library will retry requests that
        /// appear to have failed due to an intermittent problem.
        /// </summary>
        public static int MaxNetworkRetries
        {
            get => maxNetworkRetries;

            set
            {
                if (value != maxNetworkRetries)
                {
                    OpenAIClient = null;
                }

                maxNetworkRetries = value;
            }
        }

        /// <summary>
        /// Gets or sets a custom <see cref="OpenAIClient"/> for sending requests to OpenAI's
        /// API. You can use this to use a custom message handler, set proxy parameters, etc.
        /// </summary>
        /// <example>
        /// To use a custom message handler:
        /// <code>
        /// System.Net.Http.HttpMessageHandler messageHandler = ...;
        /// var httpClient = new System.Net.HttpClient(messageHandler);
        /// var openAIClient = new OpenAI.OpenAIClient(
        ///     openAIApiKey,
        ///     httpClient: new OpenAI.SystemNetHttpClient(httpClient));
        /// OpenAI.OpenAIConfiguration.OpenAIClient = openAIClient;
        /// </code>
        /// </example>
        public static IOpenAIClient OpenAIClient
        {
            get => openAIClient ??= BuildDefaultOpenAIClient();

            set => openAIClient = value;
        }

        /// <summary>Gets the version of the OpenAI client library.</summary>
        internal static string OpenAIClientVersion { get; }

        /// <summary>
        /// Returns a new instance of <see cref="Newtonsoft.Json.JsonSerializerSettings"/> with
        /// the default settings used by OpenAI.
        /// </summary>
        /// <returns>A <see cref="Newtonsoft.Json.JsonSerializerSettings"/> instance.</returns>
        public static JsonSerializerSettings DefaultSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new OpenAIObjectConverter(),
                },
                DateParseHandling = DateParseHandling.None,
                MaxDepth = 128,
            };
        }

        private static OpenAIClient BuildDefaultOpenAIClient()
        {
            if (ApiKey is { Length: 0 })
            {
                const string message = "Your API key is invalid, as it is an empty string. You can "
                                       + "double-check your API key from the OpenAI Dashboard. See "
                                       + "https://beta.openai.com/docs/api-reference/authentication for details";
                throw new OpenAIException(message);
            }

            if (ApiKey != null && StringUtils.ContainsWhitespace(ApiKey))
            {
                const string message = "Your API key is invalid, as it contains whitespace. You can "
                                       + "double-check your API key from the OpenAI Dashboard. See "
                                       + "https://beta.openai.com/docs/api-reference/authentication for details";
                throw new OpenAIException(message);
            }

            var httpClient = new SystemNetHttpClient(
                httpClient: null,
                maxNetworkRetries: MaxNetworkRetries);
            return new OpenAIClient(ApiKey, OrganizationId, httpClient: httpClient);
        }
    }
}
