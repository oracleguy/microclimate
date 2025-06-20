using ClimateApi.Db;
using ClimateApi.Model;

namespace ClimateApi;

internal class DataOverview : IDataOverview
{
    private readonly ITimeSeriesStore timeSeriesStore;
    private readonly ClimateContext context;

    public DataOverview(ITimeSeriesStore timeSeriesStore,
        ClimateContext context)
    {
        this.timeSeriesStore = timeSeriesStore;
        this.context = context;
    }

    public int GetDaysStored()
    {
        throw new NotImplementedException();
    }

    public Snapshot GetToday()
    {
        throw new NotImplementedException();
    }

    public Snapshot GetYesterday()
    {
        throw new NotImplementedException();
    }

    public List<Snapshot> OnThisDay()
    {
        throw new NotImplementedException();
    }
}