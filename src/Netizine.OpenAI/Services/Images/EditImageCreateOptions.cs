// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    public class EditImageCreateOptions : BaseOptions
    {
        /// <summary>
        /// The image to edit. Must be a valid PNG file, less than 4MB, and square.
        /// If mask is not provided, image must have transparency, which will be used as the mask.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// The image source path.
        /// </summary>
        [JsonIgnore]
        public byte[] ImageSource { get; set; }

        /// <summary>
        /// An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited.
        /// Must be a valid PNG file, less than 4MB, and have the same dimensions as image.
        /// </summary>
        [JsonProperty("mask")]
        public string Mask { get; set; }

        /// <summary>
        /// The image mask source path.
        /// </summary>
        [JsonIgnore]
        public byte[] MaskSource { get; set; }

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
