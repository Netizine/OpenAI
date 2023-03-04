// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class FileCreateOptions.
    /// Implements the <see cref="OpenAI.BaseOptions" />.
    /// </summary>
    /// <seealso cref="OpenAI.BaseOptions" />
    public class FileCreateOptions : BaseOptions
    {
        /// <summary>
        /// Gets or sets the purpose.
        /// </summary>
        /// <value>The purpose.</value>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [JsonProperty("file")]
        public string File { get; set; }

        /// <summary>
        /// The file source path.
        /// </summary>
        /// <value>The file source.</value>
        [JsonIgnore]
        public byte[] FileSource { get; set; }
    }
}
