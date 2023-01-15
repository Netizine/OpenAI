using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class EngineListResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("data")]
    public List<Engine> Engines { get; set; }
}
