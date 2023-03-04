// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// The events.
    /// </summary>
    public class Event : IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the created at date.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}