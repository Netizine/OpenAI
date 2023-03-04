// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Infrastructure;

    /// <summary>
    /// Completion prompt and parameters.
    /// </summary>
    public class CompletionCreateOptions : BaseOptions
    {
        /// <summary>
        /// ID of the model to use.
        /// You can use the <see href="https://beta.openai.com/docs/api-reference/models/list">List models</see> API to see all of your available models, or see the OpenAI <see href="https://beta.openai.com/docs/models/overview">Model overview</see> for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.
        /// Note that &lt;|endoftext|&gt; is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.
        /// </summary>
        [JsonProperty("prompt")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, List<string>> Prompt { get; set; }

        /// <summary>
        /// The suffix that comes after a completion of inserted text.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// The maximum number of <see href="https://beta.openai.com/tokenizer">tokens</see> to generate in the completion.
        /// The token count of your prompt plus max_tokens cannot exceed the model's context length.
        /// Most models have a context length of 2048 tokens (except for the newest models, which support 4096).
        /// </summary>
        [JsonProperty("max_tokens")]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// What <see href="https://towardsdatascience.com/how-to-sample-from-language-models-682bceb97277">sampling temperature</see> to use. Higher values means the model will take more risks.
        /// Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// We generally recommend altering this or top_p but not both.
        /// </summary>
        [JsonProperty("temperature")]
        public int? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass.
        /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        [JsonProperty("top_p")]
        public int? TopP { get; set; }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Note: Because this parameter generates many completions, it can quickly consume your token quota.
        /// Use carefully and ensure that you have reasonable settings for max_tokens and stop.
        /// </summary>
        [JsonProperty("n")]
        public int? N { get; set; }

        /// <summary>
        /// Whether to stream back partial progress.
        /// If set, tokens will be sent as data-only <see href="https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format">server-sent events</see> as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        [JsonProperty("stream")]
        public bool? Stream { get; set; }

        /// <summary>
        /// Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens.
        /// For example, if logprobs is 5, the API will return a list of the 5 most likely tokens.
        /// The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.
        /// The maximum value for logprobs is 5.
        /// If you need more than this, please contact OpenAI through the <see href="https://help.openai.com/">Help center</see> and describe your use case.
        /// </summary>
        [JsonProperty("logprobs")]
        [AllowNameMismatch]
        public int? LogProbs { get; set; }

        /// <summary>
        /// Echo back the prompt in addition to the completion.
        /// </summary>
        [JsonProperty("echo")]
        public bool? Echo { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens.
        /// The returned text will not contain the stop sequence.
        /// </summary>
        [JsonProperty("stop")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, List<string>> Stop { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0.
        /// Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
        /// <see href="https://beta.openai.com/docs/api-reference/parameter-details">See more information about frequency and presence penalties</see>.
        /// </summary>
        [JsonProperty("presence_penalty")]
        public int? PresencePenalty { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0.
        /// Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// <see href="https://beta.openai.com/docs/api-reference/parameter-details">See more information about frequency and presence penalties</see>.
        /// </summary>
        [JsonProperty("frequency_penalty")]
        public int? FrequencyPenalty { get; set; }

        /// <summary>
        /// Generates best_of completions server-side and returns the "best" (the one with the highest log probability per token). Results cannot be streamed.
        /// When used with n, best_of controls the number of candidate completions and n specifies how many to return – best_of must be greater than n.
        /// Note: Because this parameter generates many completions, it can quickly consume your token quota.
        /// Use carefully and ensure that you have reasonable settings for max_tokens and stop.
        /// </summary>
        [JsonProperty("best_of")]
        public int? BestOf { get; set; }

        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a json object that maps tokens (specified by their token ID in the GPT tokenizer) to an associated bias value from -100 to 100.
        /// You can use this <see href="https://beta.openai.com/tokenizer?view=bpe">tokenizer tool</see> (which works for both GPT-2 and GPT-3) to convert text to token IDs.
        /// Mathematically, the bias is added to the logits generated by the model prior to sampling.
        /// The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.
        /// As an example, you can pass {"50256": -100} to prevent the &lt;|endoftext|&gt; token from being generated.
        /// </summary>
        [JsonProperty("logit_bias")]
        public Dictionary<string, string> LogitBias { get; set; }
    }
}
