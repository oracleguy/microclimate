using InfluxDB.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClimateApi.Db;

public static class ServiceExtension
{
    public static IServiceCollection AddClimateDatabase(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ClimateContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        return services;
    }

    public static IServiceCollection AddInfluxDb(this IServiceCollection services, InfluxConfig config)
    {
        services.AddSingleton<InfluxConfig>(config);
        services.AddTransient<IInfluxDBClient>((provider) =>
        {
            return new InfluxDBClient(config.Url, config.Token);
        });
        services.AddTransient<ITimeSeriesStore, InfluxStorage>();
        return services;
    }
}