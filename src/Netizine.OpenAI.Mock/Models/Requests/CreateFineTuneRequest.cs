#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Requests;
public class CreateFineTuneRequest
{
    [JsonPropertyName("training_file")]
    public string? TrainingFile { get; set; } = default!;

    [JsonPropertyName("validation_file")]
    public string? ValidationFile { get; set; } = default!;

    [JsonPropertyName("model")]
    public string? Model { get; set; } = default!;

    [JsonPropertyName("batch_size")]
    public int? BatchSize { get; set; } = default!;

    [JsonPropertyName("learning_rate_multiplier")]
    public float? LearningRateMultiplier { get; set; } = default!;

    [JsonPropertyName("prompt_loss_weight")]
    public float? PromptLossWeight { get; set; } = default!;

    [JsonPropertyName("compute_classification_metrics")]
    public bool? ComputeClassificationMetrics { get; set; } = default!;

    [JsonPropertyName("classification_n_classes")]
    public int? ClassificationNClasses { get; set; } = default!;

    [JsonPropertyName("classification_positive_class")]
    public string? ClassificationPositiveClass { get; set; } = default!;

    [JsonPropertyName("classification_betas")]
    public List<object> ClassificationBetas { get; set; } = default!;

    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; } = default!;

}
