using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using tankmonitor_service.Configs;

namespace tankmonitor_service.Workers
{
    public class FuelTotals : BackgroundService
    {
        private readonly ILogger<FuelTotals> _logger;
        private readonly WorkerConfiguration _workerConfiguration;

        public FuelTotals(ILogger<FuelTotals> logger, WorkerConfiguration workerConfiguration)
        {
            _logger = logger;
            _workerConfiguration = workerConfiguration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Console log starting message
            _logger.LogInformation("Starting Fuel Totals Report: {time}", DateTimeOffset.Now);
            while (!stoppingToken.IsCancellationRequested)
            {
                // Run C:\gemcom\bin\gemcom Utils/getfuel.caf from the current directory
                // in a command line
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c C:\\gemcom\\bin\\gemcom Utils/getfuel.caf",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                });

                // If process isn't null
                if (process != null)
                {
                    // Output the process id to console
                    Console.WriteLine("Process ID: " + process.Id);

                    // Wait for the process to exit
                    process.WaitForExit();

                    // Output the current directory to console
                    Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());

                    // Check if the ftotal22.tot, ftotal23.tot, and ftotal24.tot files exist
                    if(File.Exists("ftotal22.tot"))
                    {
                        // Console log
                        Console.WriteLine("ftotal22.tot exists");
                    }    
                    if (File.Exists("ftotal23.tot"))
                    {
                        // Console log
                        Console.WriteLine("ftotal23.tot exists");
                    }
                    if (File.Exists("ftotal24.tot"))
                    {
                        // Console log
                        Console.WriteLine("ftotal24.tot exists");
                    }
                }
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}