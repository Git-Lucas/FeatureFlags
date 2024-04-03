namespace FeatureFlags;

public record WeatherForecastForSpecificClients(
    DateOnly Date, 
    int TemperatureC, 
    string? Summary, 
    int HumidityPercentage, 
    int WindSpeedKph, 
    int PrecipitationProbability)
    : WeatherForecast(Date, TemperatureC, Summary)
{
}
