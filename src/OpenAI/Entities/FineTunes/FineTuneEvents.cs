namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI fine tune events.
    /// </summary>
    public class FineTuneEvents : OpenAIEntity<FineTuneEvents>, IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("data")]
        public List<Event> Data { get; set; }
    }
}