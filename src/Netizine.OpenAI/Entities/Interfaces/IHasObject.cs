// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Interface that identifies entities returned by OpenAI that have an `object` attribute.
    /// </summary>
    public interface IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        string Object { get; set; }
    }
}
