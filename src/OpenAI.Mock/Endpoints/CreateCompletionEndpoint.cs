using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;
using FluentValidation.Results;

namespace OpenAI.Mock.Endpoints;
public class CreateCompletionEndpoint : Endpoint<CompletionRequest, CompletionResponse>
{
    public override void Configure()
    {
        Post("/v1/completions");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<CompletionRequest>());
    }

    public override async Task HandleAsync(CompletionRequest req, CancellationToken ct)
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

        ThrowIfAnyErrors();

        var completionId = RandomIdGenerator.GenerateRandomId("cmpl-");
        var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        var secondsSinceEpoch = (int)t.TotalSeconds;
        var choices = new List<Choice>
        {
            new Choice("\n\nThis is indeed a test",0,null, "length")
        };
        var usage = new Usage(5, 7, 12);
        var response = new CompletionResponse(completionId, secondsSinceEpoch, req.Model, choices, usage);
        await SendAsync(response, 200, ct);
    }
}
