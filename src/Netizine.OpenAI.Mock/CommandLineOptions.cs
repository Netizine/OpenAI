using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using OpenAI.Mock.Security;

namespace OpenAI.Mock;

[Command(
    Name = "dotnet openai-mock",
    FullName = "dotnet-openai-mock",
    Description = "A simple command-line HTTP server to mock the OpenAI API")]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
internal class CommandLineOptions
{
    private LogLevel? _logLevel;
    private bool? _useTls;

    [Option("-d|--directory <DIR>", Description = "The root directory to serve. [Current directory]")]
    [DirectoryExists]
    public string Directory { get; internal set; }

    [Option(Description = "Port to use [8080]. Use 0 for a dynamic port.")]
    [Range(0, 65535, ErrorMessage = "Invalid port. Ports must be in the range of 0 to 65535.")]
    public int? Port { get; internal set; }

    [Option("-a|--address <ADDRESS>", Description = "Address to use [127.0.0.1]")]
    public IPAddress[] Addresses { get; }

    [Option("--path-base <PATH>", Description = "The base URL path of postpended to the site url.")]
    public string PathBase { get; internal set; }

    [Option(Description = "Show less console output.")]
    public bool? Quiet { get; internal set; }

    [Option(Description = "Show more console output.")]
    public bool? Verbose { get; internal set; }

    [Option("-h|--headers <HEADER_AND_VALUE>", CommandOptionType.MultipleValue, Description = "A header to return with all file/directory responses. e.g. -h \"X-XSS-Protection: 1; mode=block\"")]
    [RegularExpression(@"^([^:]+):([^:]*)$", ErrorMessage = "Headers must have the form: HEADER:VALUE")]
    public string[] Headers { get; internal set; }

    [Option("--log <LEVEL>", Description = "For advanced diagnostics.", ShowInHelpText = false)]
    public LogLevel MinLogLevel
    {
        get
        {
            if (_logLevel.HasValue)
            {
                return _logLevel.Value;
            }

            if (Quiet == true)
            {
                return LogLevel.Error;
            }

            if (Verbose == true)
            {
                return LogLevel.Debug;
            }

            return LogLevel.Information;
        }
        private set => _logLevel = value;
    }

    [Option("-S|--tls", Description = "Enable TLS (HTTPS)")]
    public virtual bool UseTls
    {
        get
        {
            if (_useTls.HasValue)
            {
                return _useTls.Value;
            }

            return !string.IsNullOrEmpty(CertPfxPath) || !string.IsNullOrEmpty(CertPemPath);
        }
        internal set => _useTls = value;
    }

    internal bool UseTlsSpecified => _useTls.HasValue;

    [Option("--cert", Description = "A PEM encoded certificate file to use for HTTPS connections.\nDefaults to file in current directory named '" + CertificateLoader.DefaultCertPemFileName + "'")]
    [FileExists]
    public string CertPemPath { get; internal set; }

    [Option("--key", Description = "A PEM encoded private key to use for HTTPS connections.\nDefaults to file in current directory named '" + CertificateLoader.DefaultPrivateKeyFileName + "'")]
    [FileExists]
    public string PrivateKeyPath { get; internal set; }

    [Option("--pfx", Description = "A PKCS#12 certificate file to use for HTTPS connections.\nDefaults to file in current directory named '" + CertificateLoader.DefaultCertPfxFileName + "'")]
    [FileExists]
    public string CertPfxPath { get; internal set; }

    [Option("--pfx-pwd", Description = "The password to open the certificate file. (Optional)")]
    public virtual string CertificatePassword { get; internal set; }

    [Option("-z|--gzip", Description = "Enable gzip compression")]
    public bool? UseGzip { get; internal set; }

    [Option("-b|--brotli", Description = "Enable brotli compression")]
    public bool? UseBrotli { get; internal set; }

    [Option("-c|--cors", Description = "Enable CORS (It will enable CORS for all origin and all methods)")]
    public bool? EnableCors { get; internal set; }


    public string GetPathBase()
    {
        if (string.IsNullOrEmpty(PathBase))
        {
            return PathBase;
        }
        var pathBase = PathBase.Replace('\\', '/').TrimEnd('/');
        return pathBase[0] != '/' ? "/" + pathBase : pathBase;
    }

    public bool ShouldUseLocalhost()
        => Addresses == null
        || Addresses.Length == 0
        || (Addresses.Length == 1 && IPAddress.IsLoopback(Addresses[0]));


    public IDictionary<string, string> GetHeaders() =>
        Headers
            ?.Select(s =>
            {
                var sepIndex = s.IndexOf(':');
                var header = s.Substring(0, sepIndex);
                var value = sepIndex == s.Length - 1 ? null : s.Substring(sepIndex + 1).Trim();
                return (header, value);
            })
            .ToDictionary(p => p.header, p => p.value, StringComparer.OrdinalIgnoreCase);

    private static string GetVersion()
        => typeof(CommandLineOptions).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
}
