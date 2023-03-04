// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    ///  The OpenAI choice.
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the log probs.
        /// </summary>
        [JsonProperty("logprobs")]
        public string LogProbs { get; set; }

        /// <summary>
        /// Gets or sets the finish reason.
        /// </summary>
        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}