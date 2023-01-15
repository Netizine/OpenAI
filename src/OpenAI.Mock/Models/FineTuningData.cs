#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenAI.Mock.Models.Requests;

namespace OpenAI.Mock.Models;

public class FineTuningData
{
    [JsonPropertyName("object")]
    public string? Object { get; set; } = default!;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = default!;

    [JsonPropertyName("hyperparams")]
    public Hyperparams Hyperparams { get; set; } = default!;

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; } = default!;

    [JsonPropertyName("model")]
    public string Model { get; set; } = default!;

    [JsonPropertyName("training_files")]
    public List<TrainingFiles> TrainingFiles { get; set; } = default!;

    [JsonPropertyName("validation_files")]
    public List<ValidationFiles> ValidationFiles { get; set; } = default!;

    [JsonPropertyName("result_files")]
    public List<object> ResultFiles { get; set; } = default!;

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; } = default!;

    [JsonPropertyName("updated_at")]
    public int UpdatedAt { get; set; } = default!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("fine_tuned_model")]
    public object FineTunedModel { get; set; } = default!;
}
