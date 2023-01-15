using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class DeleteFileResponse
{
    public DeleteFileResponse(string id)
    {
        Object = "file";
        Id = id;
        Deleted = true;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }
}



