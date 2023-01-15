#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class ImageData
{
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    [JsonPropertyName("b64_json")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? B64Json { get; set; }
}
