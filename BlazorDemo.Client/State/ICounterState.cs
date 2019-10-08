using BlazorLib.State;
using SoloX.ActionDispatch.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.State
{
    public interface ICounterState : IState
    {
        IMyCounterState MyCounter { get; set; }
    }
}
