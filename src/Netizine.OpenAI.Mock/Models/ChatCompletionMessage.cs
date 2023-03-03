using System.Text.Json.Serialization;
using OpenAI.Mock.Models.Requests;

namespace OpenAI.Mock.Models;

public class ChatCompletionMessage
{
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChatRoles Role { get; set; } = ChatRoles.User;

    [JsonPropertyName("content")]
    public string Content { get; set; }
}