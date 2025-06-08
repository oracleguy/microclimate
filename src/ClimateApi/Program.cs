using System.Configuration;
using ClimateApi;
using ClimateApi.Db;

var builder = WebApplication.CreateBuilder(args);

var influxConfig = builder.Configuration.GetSection("Influx").Get<InfluxConfig>();
if (influxConfig == null)
{
    throw new ConfigurationErrorsException("Influx database configuration was not found.");
}

Console.Write(influxConfig);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddClimateDatabase(builder.Configuration.GetConnectionString("ClimateContext") ?? string.Empty);
builder.Services.AddInfluxDb(influxConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.ConfigureEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
