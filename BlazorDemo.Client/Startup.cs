using BlazorDemo.Client.State;
using BlazorLib.State;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SoloX.ActionDispatch.Core;
using SoloX.ActionDispatch.Core.State;

namespace BlazorDemo.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStateFactoryProvider, Impl.StateFactoryProvider>();
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
