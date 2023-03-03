using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class OpenAIErrorResponse
{
    public OpenAIErrorResponse(Error error)
    {
        Error = error;
    }

    [JsonPropertyName("error")]
    public Error Error { get; set; }
}
