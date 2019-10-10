using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLib.State;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerSideBlazor.Data;
using SoloX.ActionDispatch.Core;
using SoloX.ActionDispatch.Core.State;
using BlazorDemo.WebApp.State;

namespace ServerSideBlazor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<IWeatherForcastService, WeatherForecastService>();

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
