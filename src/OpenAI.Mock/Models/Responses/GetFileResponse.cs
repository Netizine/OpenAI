using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class GetFileResponse
{
    public GetFileResponse(string id, int bytes, int createdAt, string filename, string purpose)
    {
        Object = "file";
        Id = id;
        Bytes = bytes;
        CreatedAt = createdAt;
        Filename = filename;
        Purpose = purpose;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("bytes")]
    public int Bytes { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }

}






