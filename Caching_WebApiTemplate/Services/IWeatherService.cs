using Caching_WebApiTemplate.Models;

namespace Caching_WebApiTemplate.Services
{
    public interface IWeatherService
    {
        Task<List<WeatherForecast>> GetForecastAsync();
    }
}
