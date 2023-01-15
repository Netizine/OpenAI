using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class GetModelsEndpoint : EndpointWithoutRequest<ModelsListResponse>
{
    public override void Configure()
    {
        Get("v1/models");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var defaultModels =
            JsonSerializer.Deserialize<ModelsListResponse>(Properties.Resources.DefaultModelJson);
        Response.Object = "list";
        if (defaultModels != null)
        {
            Response.Data = defaultModels.Data;
        }

        return Task.CompletedTask;
    }
}
