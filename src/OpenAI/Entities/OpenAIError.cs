namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// The OpenAI error.
    /// </summary>
    /// <seealso cref="OpenAI.OpenAIEntity" />
    public class OpenAIError : OpenAIEntity<OpenAIError>
    {
        /*
         * For regular OpenAI API errors:
         */

        /// <summary>The OpenAI error message in a human-readable message providing more details about the error.</summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The type of error returned such as invalid_request_error.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// If the error is parameter-specific, the parameter related to the error. For example,
        /// you can use this to display a message near the correct form field.
        /// </summary>
        [JsonProperty("param")]
        public string Param { get; set; }

        /// <summary>
        /// The OpenAI error code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
