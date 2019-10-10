using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorLib.State;
using BlazorDemo.WebApp.State;
using SoloX.ActionDispatch.Core;
using SoloX.ActionDispatch.Core.State;
using BlazorDemo.Client.Client;
using BlazorDemo.Shared;

namespace BlazorDemo.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWeatherForcastService, WeatherForcastClient>();

            services.AddSingleton<IStateFactoryProvider, BlazorDemo.WebApp.Impl.StateFactoryProvider>();
            services.AddSingleton<IStateFactoryProvider, BlazorLib.Impl.StateFactoryProvider>();

            services.AddActionDispatchSupport(
                factory =>
                {
                    var state = factory.Create<IAppState>();
                    state.Counter = factory.Create<ICounterState>();
                    state.Counter.MyCounter = factory.Create<IMyCounterState>();
                    state.MyCounter = factory.Create<IMyCounterState>();

                    state.Counter.MyCounter.Count = 5;
                    state.MyCounter.Count = 15;

                    return state;
                });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
