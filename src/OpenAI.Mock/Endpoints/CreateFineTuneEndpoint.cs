using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class CreateFineTuneEndpoint : Endpoint<CreateFineTuneRequest, CreateFineTuneResponse>
{
    public override void Configure()
    {
        Post("/v1/fine-tunes");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<CreateFineTuneRequest>());
    }

    public override async Task HandleAsync(CreateFineTuneRequest req, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(req.TrainingFile))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'training_file' is a required property", req.Model));
        }
        else if (!req.TrainingFile.StartsWith("file-") || req.TrainingFile.Length != 29)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No file with ID: " + req.TrainingFile, req.TrainingFile));
        }

        ThrowIfAnyErrors();

        var response =
            JsonSerializer.Deserialize<CreateFineTuneResponse>(Properties.Resources.DefaultFineTuningJson);
        if (response != null)
        {
            response.Id = req.TrainingFile;
        }
        await SendAsync(response, 200, ct);
    }
}
