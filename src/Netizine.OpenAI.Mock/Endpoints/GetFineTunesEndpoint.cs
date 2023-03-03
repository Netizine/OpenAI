using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class GetFineTunesEndpoint : EndpointWithoutRequest<FineTunesListResponse>
{
    public override void Configure()
    {
        Get("v1/fine-tunes");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        var defaultModels =
            JsonSerializer.Deserialize<FineTunesListResponse>(Properties.Resources.DefaultFineTuneListResponse);
        Response.Object = "list";
        if (defaultModels != null)
        {
            Response.Data = defaultModels.Data;
        }

        return Task.CompletedTask;
    }

}
