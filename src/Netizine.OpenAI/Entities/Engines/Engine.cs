// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Describes and provide access to the various engines available in the OpenAI API.
    /// </summary>
    [Obsolete("This class is deprecated. Please use the OpenAI.Model class instead.")]
    public class Engine : OpenAIEntity<Engine>, IHasId, IHasObject
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
        /// The owner of the engine.
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Has the value <c>true</c> if the engine is ready, otherwise <c>false</c>.
        /// </summary>
        [JsonProperty("ready")]
        public bool Ready { get; set; }
    }
}
