using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;

public class ChatGPT3CompletionResponse {

    public ChatGPT3CompletionResponse(string id, int created, string model, List<ChatChoice> choices, Usage usage)
    {
        Id = id;
        Object = "chat.completion";
        Created = created;
        Model = model;
        Choices = choices;
        Usage = usage;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("choices")]
    public List<ChatChoice> Choices { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}
