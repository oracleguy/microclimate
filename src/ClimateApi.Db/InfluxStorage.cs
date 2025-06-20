using InfluxDB.Client;

namespace ClimateApi.Db;

internal class InfluxStorage : ITimeSeriesStore
{
    private readonly IInfluxDBClient influxClient;

    public InfluxStorage(IInfluxDBClient influxClient, InfluxConfig config)
    {
        this.influxClient = influxClient;
    }

    public double GetHighTemp(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public double GetLowTemp(DateOnly date)
    {
        throw new NotImplementedException();
    }
}