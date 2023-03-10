// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;

    /// <summary>
    /// Edit input, instruction, and parameters.
    /// </summary>
    public class EditCreateOptions : BaseOptions
    {
        /// <summary>
        /// ID of the model to use.
        /// You can use the <see href="https://beta.openai.com/docs/api-reference/models/list">List models</see> API to see all of your available models, or see the OpenAI <see href="https://beta.openai.com/docs/models/overview">Model overview</see> for descriptions of them.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The input text to use as a starting point for the edit.
        /// </summary>
        [JsonProperty("input")]
        public string Input { get; set; }

        /// <summary>
        /// The instruction that tells the model how to edit the prompt.
        /// </summary>
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        /// <summary>
        /// How many edits to generate for the input and instruction.
        /// </summary>
        [JsonProperty("n")]
        public int? N { get; set; }

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
    }
}
