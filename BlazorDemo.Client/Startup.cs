using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorLib.State;
using BlazorDemo.WebApp.State;
using SoloX.ActionDispatch.Core;
using SoloX.ActionDispatch.Core.State;
using SoloX.ActionDispatch.Json.State;
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

            services.AddSingleton<IInitialStateFactory<IAppState>, InitialStateFactory>();

            services.AddActionDispatchSupport<IAppState>(ServiceLifetime.Singleton, false);

            services.AddActionDispatchStateJsonSupport();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
