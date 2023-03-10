// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for OpenAI options classes, i.e. classes representing parameters for OpenAI
    /// API requests.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseOptions : INestedOptions
    {
        /// <summary>Specifies which fields in the response should be expanded.</summary>
        [JsonProperty("expand", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Expand { get; set; }

        /// <summary>Dictionary containing extra request parameters.</summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtraParams { get; set; }
            = new Dictionary<string, object>();

        /// <summary>
        /// Adds a collection of <c>expand</c> values to the request, to request expansion of
        /// specific fields in the response. When requesting expansions in a list request, don't
        /// forget to prefix the field names with <c>data.</c>.
        /// </summary>
        /// <param name="values">The collection of names of the fields to expand.</param>
        public void AddRangeExpand(IEnumerable<string> values)
        {
            Expand ??= new List<string>();

            Expand.AddRange(values);
        }

        /// <summary>
        /// Adds an extra parameter to the request. This can be useful if you need to use
        /// parameters not available in regular options classes, e.g. for beta features.
        /// </summary>
        /// <param name="key">The parameter's key.</param>
        /// <param name="value">The parameter's value.</param>
        public void AddExtraParam(string key, object value)
        {
            ExtraParams.Add(key, value);
        }
    }
}
