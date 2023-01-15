using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace OpenAI.Mock.Headers;

internal static class HeadersExtensions
{
    public static IApplicationBuilder UseHeaders(this IApplicationBuilder app, HeadersOptions options)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        return app.UseMiddleware<HeadersMiddleware>(Options.Create(options));
    }
}
