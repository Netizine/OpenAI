using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class TrainingFiles
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("bytes")]
    public int Bytes { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Filename { get; set; }

    [JsonPropertyName("purpose")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Purpose { get; set; }

    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Status { get; set; } = default!;

    [JsonPropertyName("status_details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object StatusDetails { get; set; } = default!;
}
