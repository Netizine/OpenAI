namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI hyperparams.
    /// </summary>
    /// <seealso cref="OpenAI.IHasObject" />
    public class Hyperparams : IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the size of the batch.
        /// </summary>
        [JsonProperty("batch_size")]
        public int? BatchSize { get; set; }

        /// <summary>
        /// Gets or sets the n epochs.
        /// </summary>
        [JsonProperty("n_epochs")]
        public int? NEpochs { get; set; }

        /// <summary>
        /// Gets or sets the prompt loss weight.
        /// </summary>
        [JsonProperty("prompt_loss_weight")]
        public float? PromptLossWeight { get; set; }
    }
}