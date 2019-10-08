using BlazorLib.Action;
using BlazorLib.State;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SoloX.ActionDispatch.Core.Dispatch;
using SoloX.ActionDispatch.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLib
{
    public class MyCounterBase : ComponentBase, IDisposable
    {
        private IDisposable subscription;

        [Inject]
        public ILogger<MyCounterBase> Logger { get; set; }

        public int CurrentCount { get; set; }

        [Parameter]
        public IRelativeDispatcher<IMyCounterState> Dispatcher { get; set; }

        public void IncrementCount()
        {
            Logger.LogInformation("Inc by one!");

            Dispatcher.Dispatch(new IncMyCounterBehavior(), s => s);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            subscription = Dispatcher.State.SelectWhenChanged(s => s).Subscribe((s)=>
            {
                CurrentCount = s.Count;
                this.StateHasChanged();
            });
        }

        public void Dispose()
        {
            subscription.Dispose();
        }
    }
}
