namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The embedding data.
    /// </summary>
    public class EmbeddingData : IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        [JsonProperty("index")]
        public int? Index { get; set; }

        /// <summary>
        /// Gets or sets the embedding values.
        /// </summary>
        [JsonProperty("embedding")]
        public List<float> Embedding { get; set; }
    }
}