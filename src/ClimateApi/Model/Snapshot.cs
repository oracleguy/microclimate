namespace ClimateApi.Model;

public record Snapshot
{
    public DateOnly Date { get; }

    public double LowTemp { get; }

    public double HighTemp { get; }

    public TimeSpan SunDuration { get; }
}