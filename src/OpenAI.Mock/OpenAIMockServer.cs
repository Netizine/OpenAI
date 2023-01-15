using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenAI.Mock.Headers;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;
using OpenAI.Mock.Security;

namespace OpenAI.Mock;

internal class OpenAIMockServer
{
    private readonly CommandLineOptions _options;
    private readonly IConsole _console;
    private readonly string _currentDirectory;
    private readonly IReporter _reporter;

    public OpenAIMockServer(CommandLineOptions options, IConsole console, string currentDirectory)
    {
        _options = options;
        _console = console;
        _currentDirectory = currentDirectory;
        _reporter = new ConsoleReporter(console)
        {
            IsQuiet = options.Quiet == true,
            IsVerbose = options.Verbose == true,
        };
    }

    public async Task<int> RunAsync(CancellationToken cancellationToken)
    {
        var directory = Path.GetFullPath(_options.Directory ?? _currentDirectory);
        var port = _options.Port;

        if (!CertificateLoader.TryLoadCertificate(_options, _currentDirectory, out var cert, out var certLoadError))
        {
            _reporter.Verbose(certLoadError.ToString());
            _reporter.Error(certLoadError.Message);
            return 1;
        }

        if (cert != null)
        {
            _reporter.Verbose($"Using certificate {cert.SubjectName.Name} ({cert.Thumbprint})");
        }

        void ConfigureHttps(ListenOptions options)
        {
            if (cert != null)
            {
                options.UseHttps(cert);
            }
        }

        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            ContentRootPath = directory,
            WebRootPath = directory,
            EnvironmentName = "Production"

        });

        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(_options.MinLogLevel);
        builder.Logging.AddConsole();

        builder.WebHost.UseKestrel(o =>
        {
            if (_options.ShouldUseLocalhost())
            {
                if (port.GetValueOrDefault() == 0)
                {
                    o.ListenAnyIP(0, ConfigureHttps);
                }
                else
                {
                    o.ListenLocalhost(port.GetValueOrDefault(), ConfigureHttps);
                }
            }
            else
            {
                foreach (var a in _options.Addresses)
                {
                    o.Listen(a, port.GetValueOrDefault(), ConfigureHttps);
                }
            }
        });

        builder.Services.AddSingleton(_options);

        if (_options.UseGzip == true || _options.UseBrotli == true)
        {
            builder.Services.AddResponseCompression(options =>
            {
                options.Providers.Clear();
                if (_options.UseGzip == true || _options.UseBrotli == true)
                {
                    options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
                }

                if (_options.UseGzip == true)
                {
                    options.Providers.Add<GzipCompressionProvider>();
                }


                if (_options.UseBrotli == true)
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                }
            });
        }


        builder.Services.AddFastEndpoints();
        builder.Services.AddResponseCaching();

        if (_options.EnableCors == true)
        {
            builder.Services.AddCors();
        }

        var app = builder.Build();
        app.UseOpenAIExceptionHandler();
        var headers = _options.GetHeaders();
        if (headers is { Count: > 0 })
        {
            app.UseHeaders(new HeadersOptions
            {
                Headers = headers
            });
        }

        if (_options.UseGzip == true || _options.UseBrotli == true)
        {
            app.UseResponseCompression();
        }

        // app.UseStatusCodePages("text/html",
        //            "<html><head><title>Error {0}</title></head><body><h1>HTTP {0}</h1></body></html>");
        // app.UseDeveloperExceptionPage();

        if (_options.EnableCors == true)
        {
            app.UseCors(corsPolicy =>
            {
                corsPolicy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        }
        app.UseResponseCaching();
        app.UseFastEndpoints(c =>
        {
            c.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
            {
                var validationError = failures.First();
                var error = new Error(validationError.ErrorMessage, validationError.PropertyName, null, null);
                if (validationError.ErrorMessage.EndsWith("not found"))
                {
                    ctx.Response.StatusCode = 404;
                }
                return new OpenAIErrorResponse(error);
            };
        });

        _console.Write(ConsoleColor.DarkYellow, "Starting OpenAI mock server");
        _console.WriteLine(Path.GetRelativePath(_currentDirectory, directory));


        await app.StartAsync(cancellationToken);
        AfterServerStart(app);
        await app.WaitForShutdownAsync(cancellationToken);
        return 0;
    }

    private void AfterServerStart(WebApplication app)
    {
        ((IApplicationBuilder)app).Properties["server.Features"] = ((IApplicationBuilder)app).ServerFeatures;

        if (((IApplicationBuilder)app).Properties["server.Features"] is Microsoft.AspNetCore.Http.Features.FeatureCollection)
        {
            var featureCollection = (Microsoft.AspNetCore.Http.Features.FeatureCollection)((IApplicationBuilder)app).Properties["server.Features"];
            if (featureCollection != null)
            {
                var addresses = featureCollection.Get<IServerAddressesFeature>();
                var pathBase = _options.GetPathBase();

                _console.WriteLine(GetListeningAddressText(addresses));
                foreach (var a in addresses.Addresses)
                {
                    _console.WriteLine(ConsoleColor.Green, "  " + NormalizeToLoopbackAddress(a) + pathBase);
                }
                _console.WriteLine("");
                _console.WriteLine("Press CTRL+C to exit");
            }
        }

        static string GetListeningAddressText(IServerAddressesFeature addresses)
        {
            if (addresses.Addresses.Any())
            {
                var url = addresses.Addresses.First();
                if (url.Contains("0.0.0.0") || url.Contains("[::]"))
                {
                    return "Listening on any IP:";
                }
            }

            return "Listening on:";
        }

        static string NormalizeToLoopbackAddress(string url)
        {
            // normalize to loopback if binding to IPAny
            url = url.Replace("0.0.0.0", "localhost");
            url = url.Replace("[::]", "localhost");

            return url;
        }
    }
}
