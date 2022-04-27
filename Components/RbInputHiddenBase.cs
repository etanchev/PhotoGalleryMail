using Microsoft.AspNetCore.Components.Forms;

namespace PhotoGalleryMail.Components
{
    public class RbInputHiddenBase : InputBase<string>
    {
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}
