// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// The OpenAI training files.
    /// </summary>
    public class TrainingFiles : IHasId, IHasObject
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
        /// Gets or sets the bytes.
        /// </summary>
        [JsonProperty("bytes")]
        public int? Bytes { get; set; }

        /// <summary>
        /// Gets or sets the created at date and time.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        [JsonProperty("filename")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }
    }
}