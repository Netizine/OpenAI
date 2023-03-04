// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Infrastructure;

    /// <summary>
    /// The OpenAI list.
    /// </summary>
    /// <typeparam name="T">The type parameter.</typeparam>
    [JsonObject]
    public class OpenAIList<T> : OpenAIEntity<OpenAIList<T>>, IHasObject, IEnumerable<T>
    {
        /// <summary>
        /// A string describing the object type returned.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// A list containing the actual response elements, paginated by any request parameters.
        /// </summary>
        [JsonProperty("data", ItemConverterType = typeof(OpenAIObjectConverter))]
        public List<T> Data { get; set; }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Reverse the order of the items in Data to support backward iteration.
        /// </summary>
        public void Reverse()
        {
            Data.Reverse();
        }
    }
}
