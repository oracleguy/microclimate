using Microsoft.EntityFrameworkCore;

namespace ClimateApi.Db;

public class WeekAverage
{
    public int Id { get; set; }

    public int Year { get; set; }

    public int Week { get; set; }

    public double High { get; set; }

    public double Low { get; set; }
}