using BlazorDemo.Shared;
using BlazorDemo.WebApp.State;
using SoloX.ActionDispatch.Core.Action;
using SoloX.ActionDispatch.Core.Dispatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.WebApp.Action
{
    public class LoadWeatherForcastBehavior : IActionBehaviorAsync<IWeatherState>
    {
        private IWeatherForcastService weatherForcastService;

        public LoadWeatherForcastBehavior(IWeatherForcastService weatherForcastService)
        {
            this.weatherForcastService = weatherForcastService;
        }

        public async Task Apply(IRelativeDispatcher<IWeatherState> dispatcher, IWeatherState state)
        {
            var forecasts = await this.weatherForcastService.GetForecastAsync(DateTime.Now);

            dispatcher.Dispatch(new LoadedWeatherForcastBehavior(forecasts), s => s);
        }
    }
}
