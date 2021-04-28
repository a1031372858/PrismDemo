using Common.Bases;

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
            Message = "密码错误！";
        }
    }
}