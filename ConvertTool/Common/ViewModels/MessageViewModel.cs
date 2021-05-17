using Common.Bases;
using Prism.Services.Dialogs;

namespace Common.ViewModels
{
    public class MessageViewModel:ViewModelBase
    {
        private string _message = string.Empty;
        public string Message
        {
            set => SetProperty(ref _message, value);
            get => _message;
        }

        protected override void Init()
        {
            Message = "客户端出现错误！";
        }

        protected override void DialogOpened(IDialogParameters parameters)
        {
            Message= parameters.GetValue<string>("message");
            Title = parameters.GetValue<string>("title");
        }
    }
}