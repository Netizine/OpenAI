#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models.Responses;
using OpenAI.Mock.Models;
using OpenAI.Mock.Validators;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace OpenAI.Mock.Endpoints;
public class CreateImageEditEndpoint : EndpointWithoutRequest<CreateImageResponse>
{
    public override void Configure()
    {
        Post("/v1/images/edits");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
        AllowFileUploads(dontAutoBindFormData: true); //turns off buffering
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var boundary = HttpContext.Request.GetMultipartBoundary();
        if (string.IsNullOrEmpty(boundary))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'image' is a required property"));
            ThrowIfAnyErrors();
        }
        var tempFolder = Path.GetTempPath();
        var tempDirectory = Directory.CreateDirectory(Path.GetTempPath() + Guid.NewGuid());
        var req = new CreateImageEditRequest();
        var reader = new MultipartReader(boundary, HttpContext.Request.Body);
        while (await reader.ReadNextSectionAsync(ct) is { } section)
        {
            if (section.GetContentDispositionHeader()?.IsFileDisposition() is true)
            {
                var fileSection = section.AsFileSection();
                if (fileSection is not null)
                {
                    if (fileSection.Name == "image")
                    {
                        req.Image = Path.Combine(tempDirectory.FullName, fileSection.FileName);
                        await using var fs = System.IO.File.Create(req.Image);
                        await fileSection.Section.Body.CopyToAsync(fs, 1024 * 64, ct);
                    }
                    else if (fileSection.Name == "mask")
                    {
                        req.Mask = Path.Combine(tempDirectory.FullName, fileSection.FileName);
                        await using var fs = System.IO.File.Create(req.Mask);
                        await fileSection.Section.Body.CopyToAsync(fs, 1024 * 64, ct);
                    }
                }
            }
            else if (section.GetContentDispositionHeader()?.IsFormDisposition() is true)
            {
                var formSection = section.AsFormDataSection();
                if (formSection is not null)
                {
                    switch (formSection.Name)
                    {
                        case "prompt":
                            req.Prompt = await formSection.GetValueAsync();
                            break;
                        case "n":
                            {
                                var s = await formSection.GetValueAsync();
                                var result = int.TryParse(s, out var i);
                                req.N = i;
                                break;
                            }
                        case "size":
                            req.Size = await formSection.GetValueAsync();
                            break;
                        case "response_format":
                            req.ResponseFormat = await formSection.GetValueAsync();
                            break;
                    }
                }
            }
        }

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
                var imageOneBase64String = Convert.ToBase64String(Properties.Resources.OtterResponseOne);
                var imageTwoBase64String = Convert.ToBase64String(Properties.Resources.OtterResponseTwo);
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
        //Clean up image data as we only save them to test and we always return the same images
        try
        {
            tempDirectory.Delete(true);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Error.WriteLineAsync(ex.Message);
            Console.ResetColor();
        }
        await SendAsync(response, 200, ct);

    }
}
