namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI moderation result.
    /// </summary>
    public class ModerationResult
    {
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        [JsonProperty("categories")]
        public Categories Categories { get; set; }

        /// <summary>
        /// Gets or sets the category scores.
        /// </summary>
        [JsonProperty("category_scores")]
        public CategoryScores CategoryScores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ModerationResult"/> is flagged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if flagged; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("flagged")]
        public bool Flagged { get; set; }
    }
}