// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Infrastructure;

    /// <summary>
    /// Moderation get options class.
    /// Implements the <see cref="OpenAI.BaseOptions" />.
    /// </summary>
    /// <seealso cref="OpenAI.BaseOptions" />
    public class ModerationGetOptions : BaseOptions
    {
        /// <summary>
        /// The input text to classify.
        /// </summary>
        [JsonProperty("input")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, List<string>> Input { get; set; }

        /// <summary>
        /// Two content moderations models are available: text-moderation-stable and text-moderation-latest.
        /// The default is text-moderation-latest which will be automatically upgraded over time.
        /// This ensures you are always using our most accurate model.
        /// If you use text-moderation-stable, we will provide advanced notice before updating the model.
        /// Accuracy of text-moderation-stable may be slightly lower than for text-moderation-latest.
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
    }
}
