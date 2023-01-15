using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Choice
{

    public Choice(string text, int index)
    {
        Text = text;
        Index = index;
    }

    public Choice(string text, int index, object logProbs, string finishReason)
    {
        Text = text;
        Index = index;
        LogProbs = logProbs;
        FinishReason = finishReason;
    }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("logprobs")]
    public object LogProbs { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}
