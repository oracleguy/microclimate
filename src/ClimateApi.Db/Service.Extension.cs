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
}