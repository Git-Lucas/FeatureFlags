using System.Text.Json.Serialization;

namespace FeatureFlags;

[JsonDerivedType(typeof(WeatherForecastForSpecificClients))]
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
