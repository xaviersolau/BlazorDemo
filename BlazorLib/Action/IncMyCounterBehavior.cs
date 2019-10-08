using BlazorLib.State;
using SoloX.ActionDispatch.Core.Action;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLib.Action
{
    public class IncMyCounterBehavior : IActionBehavior<IMyCounterState>
    {
        public void Apply(IStateContainer<IMyCounterState> stateContainer)
        {
            stateContainer.LoadState();

            stateContainer.State.Count += 1;
        }
    }
}
