using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class CancelFineTuneEndpoint : EndpointWithoutRequest<CancelFineTuneResponse>
{
    public override void Configure()
    {
        Post("/v1/fine-tunes/{FineTuneId}/cancel");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var fineTuneId = Route<string>("FineTuneId");
        if (string.IsNullOrWhiteSpace(fineTuneId))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No file with ID: " + fineTuneId, fineTuneId));
        }
        else if (!fineTuneId.StartsWith("ft-") || fineTuneId.Length != 27)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No file with ID: " + fineTuneId, fineTuneId));
        }

        ThrowIfAnyErrors();

        var defaultCancelFineTune =
            JsonSerializer.Deserialize<CancelFineTuneResponse>(Properties.Resources.DefaultCancelFineTuneResponse);

        await SendAsync(defaultCancelFineTune, 200, ct);

    }
}
