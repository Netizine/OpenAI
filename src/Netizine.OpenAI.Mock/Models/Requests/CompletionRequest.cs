using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;

public class CompletionRequest
{
    public CompletionRequest()
    {

    }

    public CompletionRequest(string model, string prompt, int maxTokens, int temperature)
    {
        Model = model;
        Prompt = prompt;
        MaxTokens = maxTokens;
        Temperature = temperature;
    }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("max_tokens")]
    public int MaxTokens { get; set; }

    [JsonPropertyName("Temperature")]
    public int Temperature { get; set; }
}
