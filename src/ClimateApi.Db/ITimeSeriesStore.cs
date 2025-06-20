namespace ClimateApi.Db;

/// <summary>
/// The main interface to the time series data store.
/// </summary>
public interface ITimeSeriesStore
{
    double GetHighTemp(DateOnly date);

    double GetLowTemp(DateOnly date);
}