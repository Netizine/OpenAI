using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests
{
    public class ModerationRequest
    {
        [JsonPropertyName("input")]
        public string Input { get; set; }
    }
}

