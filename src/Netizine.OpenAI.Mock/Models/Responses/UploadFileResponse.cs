#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class UploadFileResponse
{
    public UploadFileResponse(string? id, string? purpose, string? filename, int? bytes, int? createdAt, string? status, object? statusDetails)
    {
        Object = "file";
        Id = id;
        Purpose = purpose;
        Filename = filename;
        Bytes = bytes;
        CreatedAt = createdAt;
        Status = status;
        StatusDetails = statusDetails;
    }

    [JsonPropertyName("object")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Object { get; set; } = default!;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = default!;

    [JsonPropertyName("purpose")]
    public string? Purpose { get; set; } = default!;

    [JsonPropertyName("filename")]
    public string? Filename { get; set; } = default!;

    [JsonPropertyName("bytes")]
    public int? Bytes { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public int? CreatedAt { get; set; } = default!;

    [JsonPropertyName("status")]
    public string? Status { get; set; } = default!;

    [JsonPropertyName("status_details")]
    public object? StatusDetails { get; set; } = default!;
}


