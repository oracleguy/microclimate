using ClimateApi.Db;
using ClimateApi.Model;

namespace ClimateApi;

internal static class Endpoints
{
    public static void ConfigureEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.SetupToday();
        builder.SetupYesterday();
    }

    private static void SetupToday(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/today", (IDataOverview overview) =>
        {
            return overview.GetToday();
        }).Produces<Snapshot>();
    }

    private static void SetupYesterday(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/yesterday", (IDataOverview overview) =>
        {
            return overview.GetYesterday();
        }).Produces<Snapshot>();
    }
}