using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Mock.Endpoints
{
    public class GetFineTuneEventsEndpoint : EndpointWithoutRequest<FineTuneEventsResponse>
    {
        public override void Configure()
        {
            Get("/v1/fine-tunes/{FineTuneId}/events");
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
                JsonSerializer.Deserialize<FineTuneEventsResponse>(Properties.Resources.DefaultFineTuneEventsResponse);

            await SendAsync(defaultFineTune, 200, ct);

        }
    }
}
