using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class CreateImageResponse
{
    public CreateImageResponse(int created, List<ImageData> data)
    {
        Created = created;
        Data = data;
    }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("data")]
    public List<ImageData> Data { get; set; }
}



