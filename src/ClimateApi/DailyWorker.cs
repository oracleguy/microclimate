
using ClimateApi.Core;
using ClimateApi.Db;

namespace ClimateApi;

internal class DailyWorker : BackgroundService
{
    private DateTime? lastCheck = null;
    private readonly TimeSpan checkInterval = TimeSpan.FromMinutes(1);
    private readonly IServiceProvider serviceProvider;
    private readonly IDateOperations dateOperations;

    public DailyWorker(IServiceProvider serviceProvider, IDateOperations dateOperations)
    {
        this.serviceProvider = serviceProvider;
        this.dateOperations = dateOperations;
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
        using var db = serviceProvider.GetRequiredService<ClimateContext>();

        // Check if the previous week has been processed or not.
        await ProcessWeeklySummary(timeSeries, db);

        // Save the previous day into the DB.
        if (cancellationToken.IsCancellationRequested == false &&
            db.Days.Any(x => x.Date == dateOperations.Yesterday()) == false)
        {
            await ProcessPreviousDay(timeSeries, db);
        }

        await Task.Delay(1, cancellationToken);
    }

    /// <summary>
    /// Process the completed week summary into the database if it is the start of a new week.
    /// </summary>
    /// <param name="timeSeries"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task ProcessWeeklySummary(ITimeSeriesStore timeSeries, ClimateContext context)
    {
        // We only do this on Sundays.
        if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
        {
            return;
        }

        // Calculate the identifier for the week, see if it is in the DB or not.
        await Task.Delay(1);
    }

    /// <summary>
    /// Process the completed day into the database.
    /// </summary>
    /// <param name="timeSeries"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task ProcessPreviousDay(ITimeSeriesStore timeSeries, ClimateContext context)
    {
        await Task.Delay(1);
    }
}