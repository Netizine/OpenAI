// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI usage.
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Gets or sets the prompt tokens.
        /// </summary>
        [JsonProperty("prompt_tokens")]
        public int PromptTokens { get; set; }

        /// <summary>
        /// Gets or sets the completion tokens.
        /// </summary>
        [JsonProperty("completion_tokens")]
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Gets or sets the total tokens.
        /// </summary>
        [JsonProperty("total_tokens")]
        public int TotalTokens { get; set; }
    }
}