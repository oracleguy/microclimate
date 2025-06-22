namespace ClimateApi.Model;

public record Snapshot
{
    public DateOnly Date { get; init; }

    public double LowTemp { get; init; }

    public double HighTemp { get; init; }

    public TimeSpan SunDuration { get; init; }
}