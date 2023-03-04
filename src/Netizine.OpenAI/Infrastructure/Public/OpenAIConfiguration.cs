// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;
    using Newtonsoft.Json;
    using Infrastructure;

    /// <summary>
    /// Global configuration class for OpenAI settings.
    /// </summary>
    public static class OpenAIConfiguration
    {
        private static string _apiKey;

        private static int _maxNetworkRetries = SystemNetHttpClient.DefaultMaxNumberRetries;

        private static IOpenAIClient _openAIClient;

        static OpenAIConfiguration()
        {
            var assemblyName = typeof(OpenAIConfiguration).GetTypeInfo().Assembly.FullName;
            if (assemblyName != null)
            {
                var version = new AssemblyName(assemblyName).Version;
                if (version != null)
                {
                    OpenAIClientVersion = version.ToString(3);
                }
            }
            else
            {
                OpenAIClientVersion = "1.0.8";
            }
        }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public static string ApiKey
        {
            get
            {
                return _apiKey;
            }

            set
            {
                if (value != _apiKey)
                {
                    OpenAIClient = null;
                }

                _apiKey = value;
            }
        }

        /// <summary>
        /// Organization id passed to OpenAI.
        /// </summary>
        public static string OrganizationId { get; set; }

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
            get => _maxNetworkRetries;

            set
            {
                if (value != _maxNetworkRetries)
                {
                    OpenAIClient = null;
                }

                _maxNetworkRetries = value;
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
            get => _openAIClient ??= BuildDefaultOpenAIClient();

            set => _openAIClient = value;
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
