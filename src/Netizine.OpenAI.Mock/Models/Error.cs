using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Error
{
    public Error(string message, string type, string param, string code)
    {
        Message = message;
        Type = type;
        Param = param;
        Code = code;
    }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("param")]
    public string Param { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }
}



