using System.Collections.Generic;
using FluentValidation;
using OpenAI.Mock.Models;

namespace OpenAI.Mock.Validators;

public class EngineValidator : AbstractValidator<Engine>
{
    private readonly List<string> _validEngines = new() { "babbage","ada","text-davinci-002","davinci","babbage-code-search-code",
        "text-similarity-babbage-001","text-davinci-003","code-davinci-002","text-davinci-001","curie-instruct-beta",
        "babbage-code-search-text","babbage-similarity","curie-search-query","code-search-babbage-text-001","code-cushman-001",
        "code-search-babbage-code-001","text-ada-001","text-similarity-ada-001","text-davinci-insert-002","text-embedding-ada-002",
        "ada-code-search-code","ada-similarity","code-search-ada-text-001","text-search-ada-query-001","text-curie-001",
        "text-davinci-edit-001","davinci-search-document","ada-code-search-text","text-search-ada-doc-001","code-davinci-edit-001",
        "davinci-instruct-beta","text-babbage-001","text-similarity-curie-001","code-search-ada-code-001","ada-search-query",
        "text-search-davinci-query-001","curie-similarity","davinci-search-query","text-davinci-insert-001",
        "babbage-search-document","ada-search-document","curie","text-search-babbage-doc-001","text-search-curie-doc-001",
        "text-search-curie-query-001","babbage-search-query","text-search-davinci-doc-001","text-search-babbage-query-001",
        "curie-search-document","text-similarity-davinci-001","audio-transcribe-001", "davinci-similarity" };

    public EngineValidator()
    {
        RuleFor(x => x.Id).Custom((engine, context) =>
        {
            if (!_validEngines.Contains(engine))
            {
                context.AddFailure("Engine " + engine + " not found");
            }
        });
    }
}
