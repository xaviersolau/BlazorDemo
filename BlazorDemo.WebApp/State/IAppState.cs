using BlazorLib.State;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.WebApp.State
{
    public interface IAppState : IState
    {
        IWeatherState WeatherState { get; set; }
        ICounterState Counter { get; set; }
        IMyCounterState MyCounter { get; set; }
    }
}
