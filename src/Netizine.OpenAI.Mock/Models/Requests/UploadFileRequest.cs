#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;
public class UploadFileRequest
{
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? File { get; set; } = default!;

    [JsonPropertyName("purpose")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Purpose { get; set; } = default!;
}
