using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;
public class EmbeddingsRequest
{
    [JsonPropertyName("input")]
    public string Input { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }
}


