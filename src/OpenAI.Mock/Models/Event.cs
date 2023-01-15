using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Event
{
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("level")]
    public string Level { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}
