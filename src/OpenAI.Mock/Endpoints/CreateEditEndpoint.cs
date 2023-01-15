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
public class CreateEditEndpoint : Endpoint<EditRequest, EditResponse>
{
    public override void Configure()
    {
        Post("/v1/edits");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EditRequest>());
    }

    public override async Task HandleAsync(EditRequest req, CancellationToken ct)
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

        var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        var secondsSinceEpoch = (int)t.TotalSeconds;
        var choices = new List<Choice>
        {
            new Choice("What day of the week is it?",0)
        };
        var usage = new Usage(26, 28, 54);
        var response = new EditResponse(secondsSinceEpoch, choices, usage);
        await SendAsync(response, 200, ct);
    }
}
