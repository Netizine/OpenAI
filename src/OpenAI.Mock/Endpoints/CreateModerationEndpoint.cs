using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models;
using OpenAI.Mock.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints
{
    public class CreateModerationEndpoint : Endpoint<ModerationRequest, ModerationResponse>
    {
        public override void Configure()
        {
            Post("/v1/moderations");
            AllowAnonymous();
            PreProcessors(new SecurityProcessor<ModerationRequest>());
        }

        public override async Task HandleAsync(ModerationRequest req, CancellationToken ct)
        {
            if (req == null)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error",
                    "You submitted a length-0 POST body, but must submit a JSON object. (HINT: Try submitting an empty object instead, i.e. {}. If you're using curl, you can pass -d '{}' -H 'Content-Type: application/json')"));
            }
            else if (req.Input == null)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error",
                    "You submitted a length-0 POST body, but must submit a JSON object. (HINT: Try submitting an empty object instead, i.e. {}. If you're using curl, you can pass -d '{}' -H 'Content-Type: application/json')"));
            }

            ThrowIfAnyErrors();

            var moderation =
                JsonSerializer.Deserialize<ModerationResponse>(Properties.Resources.DefaultModerationResponse);

            await SendAsync(moderation, 200, ct);
        }
    }
}