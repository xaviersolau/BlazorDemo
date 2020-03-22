using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorDemo.WebApp.State;
using SoloX.ActionDispatch.Core;
using SoloX.ActionDispatch.Core.State;
using SoloX.ActionDispatch.Json.State;
using BlazorDemo.Client.Client;
using BlazorDemo.Shared;
using System.Threading.Tasks;

namespace BlazorDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = WebAssemblyHostBuilder.CreateDefault(args);

            ConfigureServices(hostBuilder.Services);

            hostBuilder.RootComponents.Add<App>("app");

            var host = hostBuilder.Build();
            await host.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddBaseAddressHttpClient();

            services.AddSingleton<IWeatherForcastService, WeatherForcastClient>();

            services.AddSingleton<IStateFactoryProvider, BlazorDemo.WebApp.Impl.StateFactoryProvider>();
            services.AddSingleton<IStateFactoryProvider, BlazorLib.Impl.StateFactoryProvider>();

            services.AddSingleton<IInitialStateFactory<IAppState>, InitialStateFactory>();

            services.AddActionDispatchSupport<IAppState>(ServiceLifetime.Singleton, false);

            services.AddActionDispatchStateJsonSupport();
        }
    }
}
