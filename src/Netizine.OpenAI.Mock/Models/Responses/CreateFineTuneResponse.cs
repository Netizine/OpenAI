using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;
public class CreateFineTuneResponse
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
    public List<Event> Events { get; set; }

    [JsonPropertyName("fine_tuned_model")]
    public object FineTunedModel { get; set; }

    [JsonPropertyName("hyperparams")]
    public Hyperparams Hyperparams { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("ResultFiles")]
    public object[] ResultFiles { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("validation_files")]
    public object[] ValidationFiles { get; set; }

    [JsonPropertyName("training_files")]
    public List<TrainingFiles> TrainingFiles { get; set; }

    [JsonPropertyName("updated_at")]
    public int UpdatedAt { get; set; }
}


