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
public class GetFineTuneEndpoint : EndpointWithoutRequest<FineTuneResponse>
{
    public override void Configure()
    {
        Get("/v1/fine-tunes/{FineTuneId}");
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

        var defaultFineTune =
            JsonSerializer.Deserialize<FineTuneResponse>(Properties.Resources.DefaultFineTuningResponse);

        await SendAsync(defaultFineTune, 200, ct);

    }
}
