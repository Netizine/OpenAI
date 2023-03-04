// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// The OpenAI image.
    /// </summary>
    public class Image : OpenAIEntity<Image>
    {
        /// <summary>
        /// Gets or sets the created date and time.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("data")]
        public List<ImageData> Data { get; set; }
    }
}