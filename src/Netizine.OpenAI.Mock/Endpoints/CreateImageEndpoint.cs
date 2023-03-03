using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using OpenAI.Mock.Models.Responses;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Requests;
using FastEndpoints;
using OpenAI.Mock.Validators;

namespace OpenAI.Mock.Endpoints;
public class CreateImageEndpoint : Endpoint<CreateImageRequest, CreateImageResponse>
{
    public override void Configure()
    {
        Post("/v1/images/generations");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<CreateImageRequest>());
    }

    public override async Task HandleAsync(CreateImageRequest req, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(req.Prompt))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "You must provide a prompt.", req.Prompt));
        }

        if (req.N <= 0)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", req.N + " is less than the minimum of 1 - 'n'", req.N));
        }

        if (req.N != null)
        {
            if (!Enumerable.Range(1, 10).Contains((int)req.N))
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", req.N + " is greater than the maximum of 10 - 'n'", req.N));
            }
        }

        ThrowIfAnyErrors();

        if (!string.IsNullOrEmpty(req.ResponseFormat))
        {
            var formatValidator = new ImageFormatValidator();
            var formatValidationResult = await formatValidator.ValidateAsync(req.ResponseFormat, ct);

            if (!formatValidationResult.IsValid && formatValidationResult.Errors.Count > 0)
            {
                ValidationFailures.Add(new ValidationFailure("invalid_request_error", req.ResponseFormat + " is not one of ['b64_json', 'url'] - 'response_format'", req.ResponseFormat));
            }
        }

        var imageSizeValidator = new ImageSizeValidator();
        var imageSizeValidationResult = await imageSizeValidator.ValidateAsync(req.Size, ct);

        if (!imageSizeValidationResult.IsValid && imageSizeValidationResult.Errors.Count > 0)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'" + req.Size + "' is not one of ['256x256', '512x512', '1024x1024'] - 'size'", req.Size));
        }

        ThrowIfAnyErrors();

        var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        var secondsSinceEpoch = (int)t.TotalSeconds;
        var imageList = new List<ImageData>();
        if (!string.IsNullOrEmpty(req.ResponseFormat))
        {
            if (req.ResponseFormat == "url")
            {
                var image = new ImageData
                {
                    Url = "https://oaidalleapiprodscus.blob.core.windows.net/private/org-..."
                };
                for (var i = 0; i < req.N; i++)
                {
                    imageList.Add(image);
                }
            }
            else
            {
                var imageOneBase64String = Convert.ToBase64String(Properties.Resources.ImageOne);
                var imageTwoBase64String = Convert.ToBase64String(Properties.Resources.ImageTwo);
                var imageOne = new ImageData
                {
                    B64Json = imageOneBase64String
                };
                var imageTwo = new ImageData
                {
                    B64Json = imageTwoBase64String
                };
                for (var i = 0; i < req.N; i++)
                {
                    imageList.Add(req.N % 2 == 0 ? imageTwo : imageOne);
                }
            }
        }
        else
        {
            var image = new ImageData
            {
                Url = "https://oaidalleapiprodscus.blob.core.windows.net/private/org-..."
            };
            for (var i = 0; i < req.N; i++)
            {
                imageList.Add(image);
            }
        }

        var response = new CreateImageResponse(secondsSinceEpoch, imageList);
        await SendAsync(response, 200, ct);
    }
}
