using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.Shared
{
    public interface IWeatherForcastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
