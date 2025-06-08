using ClimateApi.Db;

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
        builder.MapGet("/today", () =>
        {
            return "Today";
        });
    }

    private static void SetupYesterday(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/yesterday", (ClimateContext context) =>
        {
            return "Yesterday";
        });
    }
}