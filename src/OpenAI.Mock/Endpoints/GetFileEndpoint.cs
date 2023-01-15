using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class GetFileEndpoint : EndpointWithoutRequest<GetFileResponse>
{
    public override void Configure()
    {
        Get("v1/files/{FileId}");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var fileId = Route<string>("FileId");
        if (fileId == null)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "Invalid URL (DELETE /v1/files/)"));
        }
        else
        {
            if (!fileId.StartsWith("file-"))
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No such File object: " + fileId, "id"));
            }
            else if (fileId.Length != 29)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", "No such File object: " + fileId, "id"));
            }
        }
        ThrowIfAnyErrors();

        var response = new GetFileResponse(fileId, 140, 1613779657, "mydata.jsonl", "fine-tune");
        await SendAsync(response, 200, ct);
    }
}
