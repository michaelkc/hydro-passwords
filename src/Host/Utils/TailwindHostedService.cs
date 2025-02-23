using System.Diagnostics;

namespace Host.Utils;

public class TailwindHostedService : IHostedService
{
    private readonly ILogger<TailwindHostedService> _logger;
    private Process _process;

    public TailwindHostedService(ILogger<TailwindHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            _process = Process.Start(new ProcessStartInfo
            {
                FileName = "tailwindcss",
                Arguments = "-i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --watch",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            })!;

            _process.EnableRaisingEvents = true;
            _process.OutputDataReceived += (_, e) => LogInfo(e);
            _process.ErrorDataReceived += (_, e) => LogInfo(e);

            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
        }
        catch (Exception e)
        {
            _logger.LogError("Tailwind: Error starting Tailwind. Make sure that tailwindcss standalone application is installed. Error: {Message}", e.Message);
        }

        return Task.CompletedTask;
    }

    private void LogInfo(DataReceivedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(e.Data))
        {
            _logger.LogInformation("Tailwind: {Message}", e.Data);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Tailwind: STOP");
        _process?.Kill(entireProcessTree: true);
        return Task.CompletedTask;
    }
}