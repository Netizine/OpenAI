using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models;

public class Model
{
    public Model(string id, int created, string ownedBy, List<Permission> permission, string root, object parent)
    {
        Object = "model";
        Id = id;
        Created = created;
        OwnedBy = ownedBy;
        Permission = permission;
        Root = root;
        Parent = parent;
    }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; }

    [JsonPropertyName("permission")]
    public List<Permission> Permission { get; set; }

    [JsonPropertyName("root")]
    public string Root { get; set; }

    [JsonPropertyName("parent")]
    public object Parent { get; set; }
}
