namespace OpenAI.Tests
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public static class OpenAIMockHandler
    {
        private static Process process;

        private static int port = -1;

        /// <summary>
        /// Gets the port on which openai-mock is listening, or -1 if no openai-mock process was
        /// started.
        /// </summary>
        public static int Port { get => port; }

        /// <summary>
        /// Starts a openai-mock process on an available port, if necessary.
        /// </summary>
        /// <returns>True if a openai-mock process was started, false otherwise.</returns>
        public static bool StartOpenAIMock()
        {
            // var specPath = Path.GetFullPath("openapi/spec3.json");
            // var fixturesPath = Path.GetFullPath("openapi/fixtures3.json");
            //
            // if (!File.Exists(specPath))
            // {
            //     return false;
            // }

            if ((process != null) && !process.HasExited)
            {
                Console.WriteLine($"openai-mock is already running on port #{port}");
                return true;
            }

            port = FindAvailablePort();

            Console.WriteLine($"Starting openai-mock on port #{port}...");

            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "openai-mock",
                    Arguments = $"--port {port}",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                },
            };
            try
            {
                process.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error while starting openai-mock, error message = {e.Message}");
                Environment.Exit(1);
            }

            process.BeginOutputReadLine();
            Thread.Sleep(1000);

            if (process.HasExited)
            {
                Console.Error.WriteLine($"openai-mock terminated early, status code = {process.ExitCode}");
                Environment.Exit(1);
            }

            Console.WriteLine($@"Started openai-mock, PID = #{process.Id}");

            return true;
        }

        /// <summary>
        /// Stop the openai-mock process if one was started.
        /// </summary>
        public static void StopOpenAIMock()
        {
            if ((process == null) || process.HasExited)
            {
                return;
            }

            Console.WriteLine("Stopping openai-mock...");
            process.Kill();
            process = null;
            port = -1;
            Console.WriteLine("Stopped openai-mock");
        }

        /// <summary>Finds an available TCP port.</summary>
        /// <returns>The available port.</returns>
        private static int FindAvailablePort()
        {
            TcpListener l;
            int availablePort;
            var portVariable = Environment.GetEnvironmentVariable("OPENAI_MOCK_PORT");
            if (!string.IsNullOrEmpty(portVariable))
            {
                if (!int.TryParse(portVariable, out var environmentalPort))
                {
                    l = new TcpListener(IPAddress.Loopback, 0);
                    l.Start();
                    availablePort = ((IPEndPoint)l.LocalEndpoint).Port;
                    l.Stop();
                    return availablePort;
                }

                return environmentalPort;
            }
            
            l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            availablePort = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return availablePort;
        }
    }
}
