// ReSharper disable StringLiteralTypo
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    ///   The OpenAI moderation categories.
    /// </summary>
    public class Categories
    {
        /// <summary>Gets or sets a value indicating whether this <see cref="Categories" /> is hate.</summary>
        /// <value>
        ///   <c>true</c> if hate; otherwise, <c>false</c>.</value>
        [JsonProperty("hate")]
        public bool Hate { get; set; }

        /// <summary>Gets or sets a value indicating whether the content contains hate or threatening content.</summary>
        /// <value>
        ///   <c>true</c> if the content contains hate or threatening content; otherwise, <c>false</c>.</value>
        [JsonProperty("hatethreatening")]
        public bool HateThreatening { get; set; }

        /// <summary>Gets or sets a value indicating whether the content contains self harm content.</summary>
        /// <value>
        ///   <c>true</c> if the content contains self harm; otherwise, <c>false</c>.</value>
        [JsonProperty("selfharm")]
        public bool SelfHarm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Categories"/> is sexual.
        /// </summary>
        /// <value>
        ///   <c>true</c> if sexual; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("sexual")]
        public bool Sexual { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this content contains sexual content involving minors.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the content contains sexual minors; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("sexualminors")]
        public bool SexualMinors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Categories"/> is violence.
        /// </summary>
        /// <value>
        ///   <c>true</c> if violence; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("violence")]
        public bool Violence { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this content contains violence or graphic content.
        /// </summary>
        /// <value>
        ///   <c>true</c> if contents contains violence or graphic content; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("violencegraphic")]
        public bool ViolenceGraphic { get; set; }
    }
}
