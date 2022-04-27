using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail.Components
{
    public class BSpinerBase : ComponentBase
    {

        [Parameter]
        public bool IsVisible { get; set; } 

        public  void Show()
        {
            IsVisible = true;
            StateHasChanged();
        }
        public  void Hide()
        {
            IsVisible = false;
            StateHasChanged();
        }
    }
}
