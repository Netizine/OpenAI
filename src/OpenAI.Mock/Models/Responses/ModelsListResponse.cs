using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class ModelsListResponse
{
    public ModelsListResponse()
    {
        Object = "list";
    }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("data")]
    public List<Model> Data { get; set; }
}
