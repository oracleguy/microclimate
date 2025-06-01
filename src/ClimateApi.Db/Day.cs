using Microsoft.EntityFrameworkCore;

namespace ClimateApi.Db;

[Index(nameof(Date), IsUnique = true, Name = "DayDateIndex")]
public class Day
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public double HighTemp { get; set; }

    public double LowTemp { get; set; }

    public TimeSpan SunLightDuration { get; set; }

    public double HighHumidity { get; set; }

    public double LowHumidity { get; set; }
}