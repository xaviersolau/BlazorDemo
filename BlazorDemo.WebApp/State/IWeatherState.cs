using BlazorDemo.Shared;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.WebApp.State
{
    public interface IWeatherState : IState
    {
        IEnumerable<WeatherForecast> Forecasts { get; set; }
    }
}
