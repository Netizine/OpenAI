#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class EmbeddingsData
{
    [JsonPropertyName("object")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Object { get; set; } = default!;

    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Index { get; set; } = default!;

    [JsonPropertyName("embedding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public float[] Embedding { get; set; } = default!;
}
