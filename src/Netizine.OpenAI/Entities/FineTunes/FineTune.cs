// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;

    /// <summary>
    /// Fine-tuning jobs to tailor a model to your specific training data.
    /// </summary>
    public class FineTune : OpenAIEntity<FineTune>, IHasId, IHasObject
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
        /// Gets or sets the model.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the created at date.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets the fine tuned model.
        /// </summary>
        [JsonProperty("fine_tuned_model")]
        public string FineTunedModel { get; set; }

        /// <summary>
        /// Gets or sets the hyperparams.
        /// </summary>
        [JsonProperty("hyperparams")]
        public Hyperparams Hyperparams { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the result files.
        /// </summary>
        [JsonProperty("result_files")]
        public List<ResultFiles> ResultFiles { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the validation files.
        /// </summary>
        [JsonProperty("validation_files")]
        public List<object> ValidationFiles { get; set; }

        /// <summary>
        /// Gets or sets the training files.
        /// </summary>
        [JsonProperty("training_files")]
        public List<TrainingFiles> TrainingFiles { get; set; }

        /// <summary>
        /// Gets or sets the updated at date.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }
}