// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The file content.
    /// </summary>
    public class FileContent : OpenAIEntity<FileContent>
    {
        /// <summary>
        /// The file content.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
