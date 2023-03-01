using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;

public class ChatGPT3CompletionRequest {

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("messages")]
    public List<ChatCompletionMessage> Messages { get; set; }

}
