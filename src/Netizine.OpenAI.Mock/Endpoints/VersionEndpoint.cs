using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Responses;

namespace OpenAI.Mock.Endpoints
{
    public class VersionEndpoint : EndpointWithoutRequest<VersionResponse>
    {
        public override void Configure()
        {
            Get("v1/version");
            AllowAnonymous();
        }

        public override Task HandleAsync(CancellationToken ct)
        {
            Response.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            return Task.CompletedTask;
        }
    }
}
