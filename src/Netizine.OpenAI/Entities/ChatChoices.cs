// ReSharper disable once CheckNamespace
namespace OpenAI 
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Chat Choice class.
    /// </summary>
    public class ChatChoice 
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public ChatCompletionMessage Message { get; set; }


        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the finish reason.
        /// </summary>
        /// <value>The finish reason.</value>
        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}
