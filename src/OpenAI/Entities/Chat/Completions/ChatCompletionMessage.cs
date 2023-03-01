namespace OpenAI.Entities.Chat.Completions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The messages to generate chat completions for, in the chat format.
    /// </summary>
    public class ChatCompletionMessage
    {
        /// <summary>
        /// The role (either “System”, “User”, or “Assistant”).
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChatRoles Role { get; set; } = ChatRoles.User;

        /// <summary>
        /// The content of the message.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
