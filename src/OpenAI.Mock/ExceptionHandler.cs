using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock;

internal class ExceptionHandler { }

/// <summary>
/// Extension for global exception handling
/// </summary>
public static class ExceptionHandlerExtensions
{
    /// <summary>
    /// registers the default global exception handler which will log the exceptions on the server and return a user-friendly json response to the client when unhandled exceptions occur.
    /// TIP: when using this exception handler, you may want to turn off the asp.net core exception middleware logging to avoid duplication like so:
    /// <code>
    /// "Logging": { "LogLevel": { "Default": "Warning", "Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware": "None" } }
    /// </code>
    /// </summary>
    public static IApplicationBuilder UseOpenAIExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errApp =>
        {
            errApp.Run(async ctx =>
            {
                var exHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();
                if (exHandlerFeature is not null)
                {
                    var type = exHandlerFeature.Error.GetType().Name;
                    var error = exHandlerFeature.Error.Message;

                    ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    ctx.Response.ContentType = "application/json";
                    var errorVal = new Error(error, type, null, null);
                    await ctx.Response.WriteAsJsonAsync(new OpenAIErrorResponse(errorVal));
                }
            });
        });

        return app;
    }
}
