using BlazorDemo.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Client
{
    public class WeatherForcastClient : IWeatherForcastService
    {
        private HttpClient client;

        public WeatherForcastClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return await this.client.GetJsonAsync<WeatherForecast[]>("api/SampleData/WeatherForecasts");
        }
    }
}
