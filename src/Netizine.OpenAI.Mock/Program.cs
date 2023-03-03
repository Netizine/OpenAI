using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace OpenAI.Mock;

internal class Program
{
    public static int Main(string[] args)
    {
        DebugHelper.HandleDebugSwitch(ref args);
        return new Program().Run(args);
    }

    internal int Run(params string[] args)
    {
        try
        {
            using var app = new CommandLineApplication<CommandLineOptions>();
            app.ValueParsers.Add(new IPAddressParser());
            app.Conventions.UseDefaultConventions();
            app.OnExecuteAsync(async ct => await OnRunAsync(app.Model, ct));
            app.OnValidationError(r => Error(r.ErrorMessage));
            return app.Execute(args);
        }
        catch (Exception ex)
        {
            Error("Unexpected error: " + ex.ToString());
            return 2;
        }
    }

    public List<string> Errors { get; } = new List<string>();

    private void Error(string message)
    {
        Errors.Add(message);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(message);
        Console.ResetColor();
    }

    protected virtual Task<int> OnRunAsync(CommandLineOptions options, CancellationToken ct)
    {
        var server = new OpenAIMockServer(options, PhysicalConsole.Singleton, Directory.GetCurrentDirectory());
        return server.RunAsync(ct);
    }
}
