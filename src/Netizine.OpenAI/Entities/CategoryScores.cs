// ReSharper disable StringLiteralTypo
// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    ///  The OpenAI moderation category scores.
    /// </summary>
    public class CategoryScores
    {
        /// <summary>
        /// Gets the hate content score.
        /// </summary>
        [JsonProperty("hate")]
        public float Hate { get; set; }

        /// <summary>
        /// Gets the hate threatening content score.
        /// </summary>
        [JsonProperty("hatethreatening")]
        public float HateThreatening { get; set; }

        /// <summary>
        /// Gets the self harm content score.
        /// </summary>
        [JsonProperty("selfharm")]
        public float SelfHarm { get; set; }

        /// <summary>
        /// Gets the sexual content score.
        /// </summary>
        [JsonProperty("sexual")]
        public float Sexual { get; set; }

        /// <summary>
        /// Gets the sexual content involving minors score.
        /// </summary>
        [JsonProperty("sexualminors")]
        public float SexualMinors { get; set; }

        /// <summary>
        /// Gets the violence content score.
        /// </summary>
        [JsonProperty("violence")]
        public float Violence { get; set; }

        /// <summary>
        /// Gets the violence or graphic content score.
        /// </summary>
        [JsonProperty("violencegraphic")]
        public float ViolenceGraphic { get; set; }
    }
}