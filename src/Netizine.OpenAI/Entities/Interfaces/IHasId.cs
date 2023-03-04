// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Interface that identifies entities returned by OpenAI that have an `id` attribute.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
    }
}
