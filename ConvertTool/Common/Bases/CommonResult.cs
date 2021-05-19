using Prism.Services.Dialogs;

namespace Common.Bases
{
    public class CommonResult:IDialogResult
    {
        public CommonResult(IDialogParameters parameters, ButtonResult result)
        {
            Parameters = parameters;
            Result = result;
        }

        public IDialogParameters Parameters { get; }
        public ButtonResult Result { get; }
    }
}