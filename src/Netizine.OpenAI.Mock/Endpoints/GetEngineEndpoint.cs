using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Validators;

namespace OpenAI.Mock.Endpoints;

public class GetEngineEndpoint : Endpoint<EngineRequest, Engine>
{
    public override void Configure()
    {
        Get("/v1/engines/{EngineId}");
        Tags("Deprecated");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EngineRequest>());
    }

    public override async Task HandleAsync(EngineRequest req, CancellationToken ct)
    {
        var engineId = Route<string>("EngineId");
        var engine = new Engine(engineId);
        var validator = new EngineValidator();
        var validationResult = await validator.ValidateAsync(engine, ct);

        if (!validationResult.IsValid && validationResult.Errors.Count > 0)
        {
            var validationError = validationResult.Errors.First();
            //ValidationFailures.Clear();
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", validationError.ErrorMessage, engineId));
        }

        ThrowIfAnyErrors();

        await SendAsync(engine, 200, ct);
    }
}
