using Common.Bases;
using Common.Utility;
using Prism.Commands;
using Prism.Ioc;
using SqlData;
using SqlData.Beans;
using System.Linq;
using System.Windows;
using LoginViewMode = Common.Enums.Constants.LoginViewMode;

namespace ConvertTool.ViewModels
{
    public class UpdatePasswordViewModel:ViewModelBase
    {
        public UpdatePasswordViewModel() { }

        public UpdatePasswordViewModel(LoginMainViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        public LoginMainViewModel ParentViewModel;

        private UserDetail _user;

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


        private string _password = string.Empty;
        public string Password
        {
            set => SetProperty(ref _password, value);
            get => _password;
        }

        private string _checkPassword = string.Empty;
        public string CheckPassword
        {
            set => SetProperty(ref _checkPassword, value);
            get => _checkPassword;
        }

        public DelegateCommand CheckCommand { set; get; }

        public DelegateCommand UpdatePsdCommand { set; get; }

        public DelegateCommand CancelCommand { set; get; }
        protected override void Init()
        {
            _checkCode = "666666";
        }

        protected override void RegisterCommands()
        {
            CheckCommand = new DelegateCommand(Check);
            UpdatePsdCommand = new DelegateCommand(UpdatePasswrod);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private void Cancel()
        {
            ParentViewModel.ViewMode = LoginViewMode.Login;
        }

        private void UpdatePasswrod()
        {
            if (Password != CheckPassword || string.IsNullOrEmpty(Password))
            {
                MessageUtility.ShowMessage("两次密码不一致！");
                return;
            }

            var dataContext = Container.Resolve<PostgreSqlContext>();
            if (_user != null)
            {
                _user.UserPassword = Password;
                dataContext.SaveChanges();
                ParentViewModel.ViewMode = LoginViewMode.Login;
            }
        }

        private void Check()
        {

            var context = Container.Resolve<PostgreSqlContext>();

            if (context.UserDetail.Any(o => o.Phone == Phone))
            {
                if (_checkCode == InputCode)
                {
                    _user = context.UserDetail.FirstOrDefault(o => o.Phone == Phone);
                    CheckVisibility = Visibility.Collapsed;
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