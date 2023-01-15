#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;
public class CreateImageVariationRequest
{
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; } = default!;

    [JsonPropertyName("n")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? N { get; set; } = default!;

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Size { get; set; } = default!;

    [JsonPropertyName("response_format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ResponseFormat { get; set; } = default!;
}
