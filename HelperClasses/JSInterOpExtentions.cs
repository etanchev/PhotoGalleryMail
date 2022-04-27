using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail.HelperClasses
{
    public static class JSInterOpExtentions
    {
        public static ValueTask<string> Subscribe(this IJSRuntime jsRuntime, string message, string address)
        {
            return jsRuntime.InvokeAsync<string>("subscribe", message,address);
        }
        public static ValueTask<int> SetBadge(this IJSRuntime jsRuntime, int number)
        {
            return jsRuntime.InvokeAsync<int>("setBadge", number);
        }
    }
}
