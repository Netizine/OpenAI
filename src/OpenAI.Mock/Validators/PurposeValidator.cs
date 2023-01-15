using System.Collections.Generic;
using FluentValidation;

namespace OpenAI.Mock.Validators;

public class PurposeValidator : AbstractValidator<string>
{
    private readonly List<string> _validPurpose = new() { "fine-tune", "answers", "search", "classifications" };

    public PurposeValidator()
    {
        RuleFor(x => x).Custom((purpose, context) =>
        {
            if (!_validPurpose.Contains(purpose))
            {
                context.AddFailure(purpose + " is not one of ['fine-tune', 'answers', 'search', 'classifications'");
            }
        });
    }
}
