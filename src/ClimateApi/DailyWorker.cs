
namespace ClimateApi;

internal class DailyWorker : BackgroundService
{
    private DateTime? lastCheck = null;
    private readonly TimeSpan checkInterval = TimeSpan.FromMinutes(1);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested == false)
        {
            if (lastCheck == null || DateTime.Now - lastCheck > checkInterval)
            {
                await RunUpdate(stoppingToken);
                lastCheck = DateTime.Now;
            }

            await Task.Delay(2000, stoppingToken);
        }
    }

    private async Task RunUpdate(CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
    }
}