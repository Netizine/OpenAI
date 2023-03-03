namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    public class ImageCreateOptions : BaseOptions
    {
        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// Defaults to 1.
        /// </summary>
        [JsonProperty("n")]
        public int? N { get; set; }

        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// Defaults to 1024x1024.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// The format in which the generated images are returned.
        /// Must be one of url or b64_json. Defaults to url.
        /// </summary>
        [JsonProperty("response_format")]
        public string ResponseFormat { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// <see href="https://beta.openai.com/docs/guides/safety-best-practices/end-user-ids">Learn more</see>.
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }
    }
}
