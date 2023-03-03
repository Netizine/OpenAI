namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A vector representation of a given input that can be easily consumed by machine learning models and algorithms.
    /// </summary>
    public class Embedding : OpenAIEntity<Embedding>, IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("data")]
        public List<EmbeddingData> Data { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the usage.
        /// </summary>
        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }
}