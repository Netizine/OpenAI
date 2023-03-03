using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;

public class CompletionResponse
{
    public CompletionResponse(string id, int created, string model, List<Choice> choices, Usage usage)
    {
        Id = id;
        Object = "text_completion";
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
    public List<Choice> Choices { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}
