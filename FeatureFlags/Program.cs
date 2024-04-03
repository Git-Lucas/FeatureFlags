using FeatureFlags;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

string[] summaries =
[
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
];
int[] humidityPercentages = [78, 62, 85, 45, 70];
int[] windSpeedKph = [12,8,20,15,25];
int[] precipitationProbability = [30,50,10,70,20];

app.MapGet("/weatherforecast", () =>
{
    User user = new(name: "Lucas");

    if (user.CreatedAt.Year > 2022) //Only users for last year
    {
        return Enumerable.Range(1, 5).Select(index =>
            new WeatherForecastForSpecificClients
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)],
                humidityPercentages[Random.Shared.Next(humidityPercentages.Length)],
                windSpeedKph[Random.Shared.Next(windSpeedKph.Length)],
                precipitationProbability[Random.Shared.Next(precipitationProbability.Length)]
            ))
            .ToArray();
    }

    return Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();