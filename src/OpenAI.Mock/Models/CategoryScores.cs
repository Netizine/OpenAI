using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models
{
    public class CategoryScores
    {
        [JsonPropertyName("hate")]
        public float Hate { get; set; }

        [JsonPropertyName("hatethreatening")]
        public float HateThreatening { get; set; }

        [JsonPropertyName("selfharm")]
        public float SelfHarm { get; set; }

        [JsonPropertyName("sexual")]
        public float Sexual { get; set; }

        [JsonPropertyName("sexualminors")]
        public float SexualMinors { get; set; }

        [JsonPropertyName("violence")]
        public float Violence { get; set; }

        [JsonPropertyName("violencegraphic")]
        public float ViolenceGraphic { get; set; }
    }
}