using BlazorDemo.Shared;
using BlazorDemo.WebApp.State;
using SoloX.ActionDispatch.Core.Action;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.WebApp.Action
{
    public class LoadedWeatherForcastBehavior : IActionBehavior<IWeatherState>
    {
        private IEnumerable<WeatherForecast> forecasts;
        public LoadedWeatherForcastBehavior(IEnumerable<WeatherForecast> forecasts)
        {
            this.forecasts = forecasts;
        }

        public void Apply(IStateContainer<IWeatherState> stateContainer)
        {
            stateContainer.LoadState();

            stateContainer.State.Forecasts = this.forecasts;
        }
    }
}
