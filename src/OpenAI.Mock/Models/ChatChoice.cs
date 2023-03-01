using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class ChatChoice
{

    public ChatChoice(ChatCompletionMessage message)
    {
        Message = message;
    }

    public ChatChoice(ChatCompletionMessage message, int index, string finishReason)
    {
        Message = message;
        Index = index;
        FinishReason = finishReason;
    }

    [JsonPropertyName("message")]
    public ChatCompletionMessage Message { get; set; }


    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}
