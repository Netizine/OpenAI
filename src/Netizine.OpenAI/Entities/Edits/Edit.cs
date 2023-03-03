namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// Given a prompt and an instruction, the model will return an edited version of the prompt.
    /// </summary>
    public class Edit : OpenAIEntity<Edit>, IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

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