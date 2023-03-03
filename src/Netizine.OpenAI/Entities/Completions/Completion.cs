namespace OpenAI
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// The completion model will return one or more predicted completions, and can also return the probabilities of alternative tokens at each position.
    /// </summary>
    public class Completion : OpenAIEntity<Completion>, IHasId, IHasObject
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
        /// Gets or sets the model.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the choices.
        /// </summary>
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// Gets or sets the usage.
        /// </summary>
        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }
}