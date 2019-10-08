using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLib.State
{
    public interface IMyCounterState : IState
    {
        int Count { get; set; }
    }
}
