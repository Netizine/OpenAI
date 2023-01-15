using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints;
public class GetEnginesEndpoint : EndpointWithoutRequest<EngineListResponse>
{
    public override void Configure()
    {
        Get("v1/engines");
        Tags("Deprecated");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        Response.Object = "list";
        Response.Engines = new List<Engine>
        {
            new Engine("babbage"),
            new Engine("ada"),
            new Engine("text-davinci-002"),
            new Engine("davinci"),
            new Engine("babbage-code-search-code"),
            new Engine("text-similarity-babbage-001"),
            new Engine("text-davinci-003"),
            new Engine("code-davinci-002"),
            new Engine("text-davinci-001"),
            new Engine("curie-instruct-beta"),
            new Engine("babbage-code-search-text"),
            new Engine("babbage-similarity"),
            new Engine("curie-search-query"),
            new Engine("code-search-babbage-text-001"),
            new Engine("code-cushman-001"),
            new Engine("code-search-babbage-code-001"),
            new Engine("text-ada-001"),
            new Engine("text-similarity-ada-001"),
            new Engine("text-davinci-insert-002"),
            new Engine("text-embedding-ada-002"),
            new Engine("ada-code-search-code"),
            new Engine("ada-similarity"),
            new Engine("code-search-ada-text-001"),
            new Engine("text-search-ada-query-001"),
            new Engine("text-curie-001"),
            new Engine("text-davinci-edit-001"),
            new Engine("davinci-search-document"),
            new Engine("ada-code-search-text"),
            new Engine("text-search-ada-doc-001"),
            new Engine("code-davinci-edit-001"),
            new Engine("davinci-instruct-beta"),
            new Engine("text-babbage-001"),
            new Engine("text-similarity-curie-001"),
            new Engine("code-search-ada-code-001"),
            new Engine("ada-search-query"),
            new Engine("text-search-davinci-query-001"),
            new Engine("curie-similarity"),
            new Engine("davinci-search-query"),
            new Engine("text-davinci-insert-001"),
            new Engine("babbage-search-document"),
            new Engine("ada-search-document"),
            new Engine("curie"),
            new Engine("text-search-babbage-doc-001"),
            new Engine("text-search-curie-doc-001"),
            new Engine("text-search-curie-query-001"),
            new Engine("babbage-search-query"),
            new Engine("text-search-davinci-doc-001"),
            new Engine("text-search-babbage-query-001"),
            new Engine("curie-search-document"),
            new Engine("text-similarity-davinci-001"),
            new Engine("audio-transcribe-001"),
            new Engine("davinci-similarity"),
        };

        return Task.CompletedTask;
    }
}
