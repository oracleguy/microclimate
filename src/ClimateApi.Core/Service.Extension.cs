using Microsoft.Extensions.DependencyInjection;

namespace ClimateApi.Core;

public static class ServiceExtension
{
    public static IServiceCollection AddClimateCore(this IServiceCollection services)
    {
        services.AddSingleton<IDateOperations, DateOperations>();
        return services;
    }
}