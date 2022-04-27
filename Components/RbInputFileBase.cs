using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail.Components
{
    public class RbInputFileBase : InputFile
    {
        
        [Parameter]
        public int FileCount { get; set; }
       
    }
}
