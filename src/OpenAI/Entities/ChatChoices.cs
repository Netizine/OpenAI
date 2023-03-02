﻿namespace OpenAI.Entities 
{
    using Newtonsoft.Json;
    using OpenAI.Entities.Chat.Completions;

    public class ChatChoice 
    {
        [JsonProperty("message")]
        public ChatCompletionMessage Message { get; set; }


        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}