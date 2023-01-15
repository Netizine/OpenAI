#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class ValidationFiles
{
    [JsonPropertyName("object")]
    public string? Object { get; set; } = default!;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = default!;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = default!;

    [JsonPropertyName("filename")]
    public string Filename { get; set; } = default!;

    [JsonPropertyName("bytes")]
    public int Bytes { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; } = default!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("status_details")]
    public object StatusDetails { get; set; } = default!;
}
