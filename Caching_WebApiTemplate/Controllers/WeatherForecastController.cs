using Caching_WebApiTemplate.Models;
using Caching_WebApiTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caching_WebApiTemplate.Controllers
{
    /// <summary>
    /// Controller for retrieving weather forecast data with various caching strategies.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CacheService _cache;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(CacheService cache, ILogger<WeatherForecastController> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        /// <summary>
        /// Returns a list of weather forecasts with hybrid caching (in-memory + Redis).
        /// Uses response caching headers for CDN support (60 seconds).
        /// </summary>
        /// <returns>A cached list of weather forecasts.</returns>
        [HttpGet("forecast")]
        [ResponseCache(Duration = 60)] // CDN cache hint
        public IActionResult Get()
        {
            const string cacheKey = "weather:forecast";
            var forecast = _cache.Get<List<WeatherForecast>>(cacheKey);

            if (forecast == null)
            {
                forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = "Sunny"
                    }).ToList();

                _cache.Set(cacheKey, forecast, TimeSpan.FromMinutes(2));
            }

            return Ok(forecast);
        }

        /// <summary>
        /// Returns a simple string message with CDN-friendly cache headers.
        /// Demonstrates manual control over Cache-Control response header.
        /// </summary>
        /// <returns>A cacheable string response.</returns>
        [HttpGet("cdn")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult GetCDNCachedData()
        {
            Response.Headers["Cache-Control"] = "public,max-age=120";
            return Ok("This is CDN-cacheable content");
        }
    }
}
