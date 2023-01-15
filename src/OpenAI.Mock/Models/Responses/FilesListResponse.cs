using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class FilesListResponse
{
    public FilesListResponse()
    {
        Object = "list";
    }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("data")]
    public List<FilesData> Data { get; set; }
}
