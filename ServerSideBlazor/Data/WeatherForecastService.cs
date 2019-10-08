using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazor.Data
{
    public class WeatherForecastService
    {
        private ILogger<WeatherForecastService> logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            this.logger = logger;

            this.logger.LogInformation("Create weather service.");
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {

            this.logger.LogInformation("Get weather...");

            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
