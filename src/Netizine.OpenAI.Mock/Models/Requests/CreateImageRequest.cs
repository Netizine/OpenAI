#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;

public class CreateImageRequest
{
    public CreateImageRequest()
    {

    }

    public CreateImageRequest(string prompt, int n, string size, string? responseFormat = null)
    {
        Prompt = prompt;
        N = n;
        Size = size;
        ResponseFormat = responseFormat;
    }

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } = default!;

    [JsonPropertyName("n")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? N { get; set; } = default!;

    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Size { get; set; } = default!;

    [JsonPropertyName("response_format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ResponseFormat { get; set; } = default!;
}




