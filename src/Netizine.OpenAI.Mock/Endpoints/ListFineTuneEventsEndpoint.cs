using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;

public class ListFineTuneEventsEndpoint : EndpointWithoutRequest<ListFineTuneEventsResponse>
{
    public override void Configure()
    {
        Get("v1/fine-tunes/{FineTuneId}/events");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
        AllowFileUploads(dontAutoBindFormData: true); //turns off buffering
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var fineTuneId = Route<string>("FineTuneId");
        if (fineTuneId == null)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No fine-tune job"));
        }
        else
        {
            if (!fineTuneId.StartsWith("ft-"))
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No fine-tune job: : " + fineTuneId, "id"));
            }
            else if (fineTuneId.Length != 26)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No fine-tune job: " + fineTuneId, "id"));
            }
        }
        ThrowIfAnyErrors();

        //DefaultListFineTuningEventsJson

        var fineTuningEvents =
            JsonSerializer.Deserialize<ListFineTuneEventsResponse>(Properties.Resources.DefaultListFineTuningEventsJson);

        await SendAsync(fineTuningEvents, 200, ct);

    }
}
