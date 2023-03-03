using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class EmbeddingsResponse
{
    public EmbeddingsResponse(List<EmbeddingsData> data, string model, Usage usage)
    {
        Object = "list";
        Data = data;
        Model = model;
        Usage = usage;
    }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("data")]
    public List<EmbeddingsData> Data { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}
