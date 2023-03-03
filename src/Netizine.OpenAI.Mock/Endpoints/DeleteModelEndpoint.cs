using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints
{
    internal class DeleteModelEndpoint : EndpointWithoutRequest<DeleteModelResponse>
    {
        public override void Configure()
        {
            Delete("v1/models/{ModelId}");
            AllowAnonymous();
            PreProcessors(new SecurityProcessor<EmptyRequest>());
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var modelId = Route<string>("ModelId");
            if (modelId == null)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", "Invalid URL (DELETE /v1/models/)"));
            }
            else
            {
                if (!modelId.Contains("ft-"))
                {
                    ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No such Model object: " + modelId, "id"));
                }
            }
            ThrowIfAnyErrors();

            var response = new DeleteModelResponse(modelId);
            await SendAsync(response, 200, ct);
        }
    }
}
