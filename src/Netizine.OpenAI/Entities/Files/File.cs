// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using Newtonsoft.Json;
    using Infrastructure;

    /// <summary>
    /// Information about a specific file.
    /// </summary>
    public class File : OpenAIEntity<File>, IHasId, IHasObject
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
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }
    }
}