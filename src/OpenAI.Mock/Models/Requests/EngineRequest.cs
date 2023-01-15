using FastEndpoints;

namespace OpenAI.Mock.Models.Requests;

public class EngineRequest
{
    [BindFrom("id")]
    public string EngineId { get; set; }
}
