using System.Diagnostics;
using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryExporter;

// Define some important constants and the activity source

var serviceName = Assembly.GetExecutingAssembly().GetName().Name;
var serviceVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOpenTelemetryTracing(providerBuilder =>
{
    providerBuilder
        .AddMyConsoleExporter() // this is a custom exporter
        .AddSource(serviceName)
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
        .AddAspNetCoreInstrumentation()
        .AddAzureMonitorTraceExporter(o =>
        {
            o.ConnectionString = builder.Configuration.GetSection("AzureMonitorTrace").Value;
        });
});

var app = builder.Build();

var myActivitySource = new ActivitySource(serviceName ?? string.Empty);

// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    // Track work inside of the request
    using var activity = myActivitySource.StartActivity("weatherforecast");

    var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();

    // Recording the event
    activity?.AddEvent(new ActivityEvent("Get Forecast",
        tags: new ActivityTagsCollection() { KeyValuePair.Create<string, object?>("forecast", forecast) }));

    // Assign random status
    var rand = new Random();
    var number = rand.NextDouble();
    activity?.SetStatus(number < 0.5 ? ActivityStatusCode.Ok : ActivityStatusCode.Error);

    return forecast;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}