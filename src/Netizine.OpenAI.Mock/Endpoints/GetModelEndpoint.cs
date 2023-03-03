using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;
using FluentValidation.Results;

namespace OpenAI.Mock.Endpoints;

public class GetModelEndpoint : Endpoint<ModelRequest, Model>
{
    public override void Configure()
    {
        Get("/v1/models/{ModelId}");
        Tags("Deprecated");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<ModelRequest>());
    }

    public override async Task HandleAsync(ModelRequest req, CancellationToken ct)
    {
        var modelId = Route<string>("ModelId");
        var defaultModels =
            JsonSerializer.Deserialize<ModelsListResponse>(Properties.Resources.DefaultModelJson);
        Model model = null;
        if (defaultModels != null)
        {
            foreach (var modelData in defaultModels.Data)
            {
                if (modelData.Id == modelId)
                {
                    model = modelData;
                    break;
                }
            }
        }

        if (model == null)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "That model does not exist", modelId));
        }

        ThrowIfAnyErrors();

        await SendAsync(model, 200, ct);

    }
}
