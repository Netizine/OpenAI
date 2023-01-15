using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenAI.Mock.Models.Responses
{
    public class DeleteModelResponse
    {
        public DeleteModelResponse(string id)
        {
            Object = "model";
            Id = id;
            Deleted = true;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
    }
}



