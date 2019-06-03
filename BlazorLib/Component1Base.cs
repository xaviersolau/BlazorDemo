using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLib
{
    public class Component1Base : ComponentBase
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }

        [Parameter]
        protected string Message { get; set; } = string.Empty;

        protected string JsMessage { get; set; } = string.Empty;

        protected async Task CallExampleJsInterop()
        {
            JsMessage = await ExampleJsInterop.Prompt(JsRuntime, "Message from .Net!");
        }
    }
}
