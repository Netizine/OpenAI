// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The embedding create options.
    /// Implements the <see cref="OpenAI.BaseOptions" />.
    /// </summary>
    /// <seealso cref="OpenAI.BaseOptions" />
    public class EmbeddingCreateOptions : BaseOptions
    {
        /// <summary>
        /// ID of the model to use.
        /// You can use the <see href="https://beta.openai.com/docs/api-reference/models/list">List models</see> API to see all of your available models, or see the OpenAI <see href="https://beta.openai.com/docs/models/overview">Model overview</see> for descriptions of them.
        /// </summary>
        /// <value>The model.</value>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        [JsonProperty("input")]
        public string Input { get; set; }
    }
}