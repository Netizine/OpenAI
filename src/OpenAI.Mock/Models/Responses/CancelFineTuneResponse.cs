using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenAI.Mock.Models.Responses;
public class CancelFineTuneResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("events")]
    public Event[] Events { get; set; }

    [JsonPropertyName("fine_tuned_model")]
    public object FineTunedModel { get; set; }

    [JsonPropertyName("hyperparams")]
    public Hyperparams Hyperparams { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("result_files")]
    public List<object> ResultFiles { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("validation_files")]
    public List<object> ValidationFiles { get; set; }

    [JsonPropertyName("training_files")]
    public List<TrainingFiles> TrainingFiles { get; set; }

    [JsonPropertyName("updated_at")]
    public int UpdatedAt { get; set; }
}




