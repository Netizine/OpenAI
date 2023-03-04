// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// List and describe the various models available in the API.
    /// You can refer to the Models documentation to understand what models are available and the differences between them.
    /// </summary>
    public class Model : OpenAIEntity<Model>, IHasId, IHasObject
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
        /// Gets or sets the created date.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets who the model is owned by.
        /// </summary>
        [JsonProperty("owned_by", NullValueHandling = NullValueHandling.Ignore)]
        public string OwnedBy { get; set; }

        /// <summary>
        /// Gets or sets the permissions.
        /// </summary>
        [JsonProperty("permission", NullValueHandling = NullValueHandling.Ignore)]
        [AllowNameMismatch]
        public List<Permission> Permissions { get; set; }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        [JsonProperty("root", NullValueHandling = NullValueHandling.Ignore)]
        public string Root { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public string Parent { get; set; }

        /// <summary>
        /// Gets or sets if the model is deleted.
        /// </summary>
        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }
    }
}
