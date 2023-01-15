using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock;
public class SecurityProcessor<TRequest> : IPreProcessor<TRequest>
{
    public Task PreProcessAsync(TRequest req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        var jwtToken = ctx.Request.Headers["Authorization"].FirstOrDefault();

        if (jwtToken is not "Bearer sk-test")
        {
            var error = new Error(
                "You didn't provide an API key. You need to provide your API key in an Authorization header using Bearer auth (i.e. Authorization: Bearer YOUR_KEY), or as the password field (with blank username) if you're accesing the API from your browser and are prompted for a username and password. You can obtain an API key from https://beta.openai.com.",
                "invalid_request_error", null, null);
            return ctx.Response.SendAsync(new OpenAIErrorResponse(error), 401, null, ct);
        }


        return Task.CompletedTask;
    }
}
