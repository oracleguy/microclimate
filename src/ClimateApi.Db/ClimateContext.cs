using Microsoft.EntityFrameworkCore;

namespace ClimateApi.Db;

public class ClimateContext : DbContext
{
    public DbSet<WeekAverage> WeekAverages { get; set; }

    public DbSet<Day> Days { get; set; }
}