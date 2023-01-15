#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenAI.Mock.Models.Responses;
public class FineTunesListResponse
{
    [JsonPropertyName("object")]
    public string? Object { get; set; } = default!;
    [JsonPropertyName("data")]
    public List<FineTuningData> Data { get; set; } = default!;
}


