using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class EmbeddingsEndpoint : Endpoint<EmbeddingsRequest, EmbeddingsResponse>
{
    public override void Configure()
    {
        Post("/v1/embeddings");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmbeddingsRequest>());
    }

    public override async Task HandleAsync(EmbeddingsRequest req, CancellationToken ct)
    {
        var defaultModels =
            JsonSerializer.Deserialize<ModelsListResponse>(Properties.Resources.DefaultModelJson);
        var modelIsValid = false;
        if (defaultModels != null)
        {
            foreach (var modelData in defaultModels.Data)
            {
                if (modelData.Id == req.Model)
                {
                    modelIsValid = true;
                    break;
                }
            }
        }

        if (!modelIsValid)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "That model does not exist", req.Model));
        }

        if (string.IsNullOrEmpty(req.Input))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'input' is a required property", req.Input));
        }

        ThrowIfAnyErrors();

        var response =
            JsonSerializer.Deserialize<EmbeddingsResponse>(Properties.Resources.DefaultEmbeddingsJson);

        await SendAsync(response, 200, ct);
    }
}
