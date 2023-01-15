using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models
{
    public class ModerationResult
    {
        [JsonPropertyName("categories")]
        public Categories Categories { get; set; }

        [JsonPropertyName("category_scores")]
        public CategoryScores CategoryScores { get; set; }

        [JsonPropertyName("flagged")]
        public bool Flagged { get; set; }
    }
}