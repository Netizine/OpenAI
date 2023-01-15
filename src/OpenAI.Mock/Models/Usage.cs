#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Usage
{
    public Usage(int? promptTokens, int? completionTokens, int? totalTokens)
    {
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
        TotalTokens = totalTokens;
    }

    [JsonPropertyName("prompt_tokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? PromptTokens { get; set; } = default!;

    [JsonPropertyName("completion_tokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? CompletionTokens { get; set; } = default!;

    [JsonPropertyName("total_tokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? TotalTokens { get; set; } = default!;
}
