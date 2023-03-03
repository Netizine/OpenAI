using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models.Responses;
using OpenAI.Mock.Validators;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace OpenAI.Mock.Endpoints;
public class UploadFileEndpoint : EndpointWithoutRequest<UploadFileResponse>
{
    public override void Configure()
    {
        Post("/v1/files");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<EmptyRequest>());
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
        var req = new UploadFileRequest();
        var reader = new MultipartReader(boundary, HttpContext.Request.Body);
        string fileName = string.Empty;
        while (await reader.ReadNextSectionAsync(ct) is { } section)
        {
            if (section.GetContentDispositionHeader()?.IsFileDisposition() is true)
            {
                var fileSection = section.AsFileSection();
                if (fileSection is not null)
                {
                    if (fileSection.Name == "file")
                    {
                        fileName = fileSection.FileName;
                        req.File = Path.Combine(tempDirectory.FullName, fileSection.FileName);
                        await using var fs = System.IO.File.Create(req.File);
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
                        case "purpose":
                            req.Purpose = await formSection.GetValueAsync();
                            break;
                    }
                }
            }
        }

        if (string.IsNullOrEmpty(req.File))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'file' is a required property", req.File));
        }
        if (string.IsNullOrEmpty(req.Purpose))
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'purpose' is a required property", req.Purpose));
        }

        ThrowIfAnyErrors();

        var purposeValidator = new PurposeValidator();
        var purposeValidationResult = await purposeValidator.ValidateAsync(req.Purpose, ct);

        if (!purposeValidationResult.IsValid && purposeValidationResult.Errors.Count > 0)
        {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "'" + req.Purpose + " is not one of ['fine-tune', 'answers', 'search', 'classifications'] - 'purpose'", req.Purpose));
        }

        ThrowIfAnyErrors();

        var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        var secondsSinceEpoch = (int)t.TotalSeconds;
        var fi = new FileInfo(Path.Combine(tempDirectory.FullName, fileName)).Length;
        var completionId = RandomIdGenerator.GenerateRandomId("file-");
        var response = new UploadFileResponse(completionId, req.Purpose, fileName, (int)fi, secondsSinceEpoch, "uploaded", null);

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

