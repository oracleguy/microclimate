using Microsoft.EntityFrameworkCore;

namespace ClimateApi.Db;

public class ClimateContext : DbContext
{
    public ClimateContext(DbContextOptions<ClimateContext> options) :
        base(options)
    {
            
    }

    public DbSet<WeekAverage> WeekAverages { get; set; }

    public DbSet<Day> Days { get; set; }

    public DbSet<Setting> Settings { get; set; }
}