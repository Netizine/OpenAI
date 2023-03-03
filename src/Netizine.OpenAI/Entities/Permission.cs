namespace OpenAI
{
    using System;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// The OpenAI permission.
    /// </summary>
    public class Permission : IHasId, IHasObject
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the created date and time.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow creating a engine.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a user is allowed to create a engine; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_create_engine")]
        public bool AllowCreateEngine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow sampling.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allowing sampling; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_sampling")]
        public bool AllowSampling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow logprobs.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allowing logprobs; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_logprobs")]
        public bool AllowLogprobs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow search indices.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allowing search indices; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_search_indices")]
        public bool AllowSearchIndices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow view.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allowing view; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_view")]
        public bool AllowView { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow fine tuning.
        /// </summary>
        /// <value>
        ///   <c>true</c> if allowing fine tuning; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("allow_fine_tuning")]
        public bool AllowFineTuning { get; set; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        [JsonProperty("organization")]
        public string Organization { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        [JsonProperty("group")]
        public object Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is blocking.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is blocking; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_blocking")]
        public bool IsBlocking { get; set; }
    }
}
