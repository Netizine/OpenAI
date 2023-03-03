using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Permission
{
    public Permission()
    {

    }

    public Permission(string id, string objectName, int created, bool allowCreateEngine, bool allowSampling,
        bool allowLogprobs, bool allowSearchIndices, bool allowView, bool allowFineTuning, string organization,
        object group, bool isBlocking)
    {
        Id = id;
        Object = objectName;
        Created = created;
        AllowCreateEngine = allowCreateEngine;
        AllowSampling = allowSampling;
        AllowLogprobs = allowLogprobs;
        AllowSearchIndices = allowSearchIndices;
        AllowView = allowView;
        AllowFineTuning = allowFineTuning;
        Organization = organization;
        Group = group;
        IsBlocking = isBlocking;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("allow_create_engine")]
    public bool AllowCreateEngine { get; set; }

    [JsonPropertyName("allow_sampling")]
    public bool AllowSampling { get; set; }

    [JsonPropertyName("allow_logprobs")]
    public bool AllowLogprobs { get; set; }

    [JsonPropertyName("allow_search_indices")]
    public bool AllowSearchIndices { get; set; }

    [JsonPropertyName("allow_view")]
    public bool AllowView { get; set; }

    [JsonPropertyName("allow_fine_tuning")]
    public bool AllowFineTuning { get; set; }

    [JsonPropertyName("organization")]
    public string Organization { get; set; }

    [JsonPropertyName("group")]
    public object Group { get; set; }

    [JsonPropertyName("is_blocking")]
    public bool IsBlocking { get; set; }
}

