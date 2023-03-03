#nullable enable
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Hyperparams
{
    [JsonPropertyName("batch_size")]
    public int? BatchSize { get; set; } = default!;

    [JsonPropertyName("learning_rate_multiplier")]
    public float? LearningRateMultiplier { get; set; } = default!;

    [JsonPropertyName("n_epochs")]
    public int? NEpochs { get; set; } = default!;

    [JsonPropertyName("prompt_loss_weight")]
    public float? PromptLossWeight { get; set; } = default!;
}
