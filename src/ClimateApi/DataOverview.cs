using ClimateApi.Core;
using ClimateApi.Db;
using ClimateApi.Model;

namespace ClimateApi;

internal class DataOverview : IDataOverview
{
    private readonly ITimeSeriesStore timeSeriesStore;
    private readonly ClimateContext context;
    private readonly IDateOperations dateOperations;

    public DataOverview(ITimeSeriesStore timeSeriesStore,
        ClimateContext context, IDateOperations dateOperations)
    {
        this.timeSeriesStore = timeSeriesStore;
        this.context = context;
        this.dateOperations = dateOperations;
    }

    public int GetDaysStored()
    {
        return context.Days.Count();
    }

    public Snapshot GetToday()
    {
        throw new NotImplementedException();
    }

    public Snapshot GetYesterday()
    {
        return GetSnapshotForDay(DateOnly.FromDateTime(DateTime.Now.AddDays(-1))) ??
            new Snapshot();
    }

    public List<Snapshot> OnThisDay()
    {
        return [.. dateOperations.GetPreviousFiveYears(DateOnly.FromDateTime(DateTime.Now)).Select(GetSnapshotForDay).Where(y => y != null)];
    }

    private Snapshot? GetSnapshotForDay(DateOnly date)
    {
        var data = context.Days.FirstOrDefault(x => x.Date == date);
        if (data != null)
        {
            return new Snapshot
            {
                Date = date,
                HighTemp = data.HighTemp,
                LowTemp = data.LowTemp,
                SunDuration = data.SunLightDuration
            };
        }

        return null;
    }
}