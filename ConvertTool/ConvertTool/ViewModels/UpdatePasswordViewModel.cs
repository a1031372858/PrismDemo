using System.Linq;
using System.Windows;
using Common.Bases;
using Common.Utility;
using Common.ViewModels;
using Common.Views;
using Prism.Commands;
using Prism.Ioc;
using SqlData;

namespace ConvertTool.ViewModels
{
    public class UpdatePasswordViewModel:ViewModelBase
    {

        private string _phone = string.Empty;
        public string Phone
        {
            set => SetProperty(ref _phone, value);
            get => _phone;
        }

        private string _checkCode = string.Empty;

        private string _inputCode = string.Empty;
        public string InputCode
        {
            set => SetProperty(ref _inputCode, value);
            get => _inputCode;
        }

        private Visibility _checkVisibility = Visibility.Visible;
        public Visibility CheckVisibility
        {
            set => SetProperty(ref _checkVisibility, value);
            get => _checkVisibility;
        }

        public DelegateCommand CheckCommand { set; get; }

        protected override void Init()
        {
            _checkCode = "666666";
        }

        protected override void RegisterCommands()
        {
            CheckCommand = new DelegateCommand(Check);
        }

        private void Check()
        {

            var context = Container.Resolve<PostgreSqlContext>();

            var userList = context.UserDetail.ToList();
            if (userList.Any(o => o.Phone == Phone))
            {
                if (_checkCode == InputCode)
                {

                }
                else
                {
                    MessageUtility.ShowMessage("验证码输入错误！");
                    return;
                }
            }
            else
            {
                MessageUtility.ShowMessage("手机号输入错误或未注册！");
                return;
            }
        }
    }
}