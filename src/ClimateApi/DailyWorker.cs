
using ClimateApi.Db;

namespace ClimateApi;

internal class DailyWorker : BackgroundService
{
    private DateTime? lastCheck = null;
    private readonly TimeSpan checkInterval = TimeSpan.FromMinutes(1);
    private readonly IServiceProvider serviceProvider;

    public DailyWorker(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

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
        var timeSeries = serviceProvider.GetRequiredService<ITimeSeriesStore>();
        
        await Task.Delay(1, cancellationToken);
    }
}