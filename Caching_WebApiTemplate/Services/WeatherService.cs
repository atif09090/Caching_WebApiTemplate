using Caching_WebApiTemplate.Models;

namespace Caching_WebApiTemplate.Services
{
    public class WeatherService : IWeatherService
    {
        public Task<List<WeatherForecast>> GetForecastAsync()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 35),
                    Summary = "Sunny"
                }).ToList();

            return Task.FromResult(forecast);
        }
    }
}
