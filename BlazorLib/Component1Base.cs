using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
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

        [Inject]
        private ILogger<Component1Base> Logger { get; set; }

        [Parameter]
        protected string Message { get; set; } = string.Empty;

        protected string JsMessage { get; set; } = string.Empty;

        protected async Task CallExampleJsInterop()
        {
            Logger.LogInformation("Processing JS interop...");
            JsMessage = await ExampleJsInterop.Prompt(JsRuntime, "Message from .Net!");
            Logger.LogInformation($"JS interop returned {JsMessage}");
        }
    }
}
