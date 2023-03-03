#nullable enable
using System;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;
public class Engine
{
    public Engine(string id)
    {
        Object = "engine";
        Id = id;
        Ready = true;
        Owner = "openai";
    }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("ready")]
    public bool Ready { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("permissions")]
    public object? Permissions { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

}
