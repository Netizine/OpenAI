using System.Collections.Generic;
using FluentValidation;

namespace OpenAI.Mock.Validators;

public class ImageSizeValidator : AbstractValidator<string>
{
    private readonly List<string> _validSizes = new() { "256x256", "512x512", "1024x1024" };

    public ImageSizeValidator()
    {
        RuleFor(x => x).Custom((size, context) =>
        {
            if (!_validSizes.Contains(size))
            {
                context.AddFailure("Image size is not one of ['256x256', '512x512', '1024x1024']");
            }
        });
    }
}
