using FastEndpoints;

namespace OpenAI.Mock.Models.Requests;
public class ModelRequest
{
    [BindFrom("id")]
    public string ModelId { get; set; }
}
