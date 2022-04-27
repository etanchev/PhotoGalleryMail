using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail
{
    public class ModalDialogBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }
        protected bool IsVisible { get; set; }

        [Parameter]
        public EventCallback<bool> ModalDialogCallback { get; set; }
        public void  Show()
        {
            IsVisible = true;
        }
        public void Hide()
        {
            IsVisible = false;
        }

        protected async Task OnModalDialogConfirmation(bool value)
        {

            await ModalDialogCallback.InvokeAsync(value); //this call the fuction registered in ConfigDialog Inbox page
        }
    }
}
