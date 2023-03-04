// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI image data.
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the B64 json.
        /// </summary>
        [JsonProperty("b64_json")]
        public string B64Json { get; set; }
    }
}