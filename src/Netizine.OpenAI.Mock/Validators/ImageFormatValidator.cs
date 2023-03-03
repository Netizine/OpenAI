using System.Collections.Generic;
using FluentValidation;

namespace OpenAI.Mock.Validators;

public class ImageFormatValidator : AbstractValidator<string>
{
    private readonly List<string> _validFormats = new() { "url", "b64_json" };

    public ImageFormatValidator()
    {
        RuleFor(x => x).Custom((format, context) =>
        {
            if (!_validFormats.Contains(format))
            {
                context.AddFailure("Image format is not valid");
            }
        });
    }
}
