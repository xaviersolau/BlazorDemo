using BlazorLib.State;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.WebApp.State
{
    public class InitialStateFactory : IInitialStateFactory<IAppState>
    {
        private IStateFactory factory;

        public InitialStateFactory(IStateFactory factory)
        {
            this.factory = factory;
        }

        public IAppState Create()
        {
            var state = factory.Create<IAppState>();
            state.Counter = factory.Create<ICounterState>();
            state.Counter.MyCounter = factory.Create<IMyCounterState>();
            state.MyCounter = factory.Create<IMyCounterState>();
            state.WeatherState = factory.Create<IWeatherState>();

            state.Counter.MyCounter.Count = 5;
            state.MyCounter.Count = 15;

            return state;
        }
    }
}
