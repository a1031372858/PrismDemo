using Common.Bases;
using Common.Enums;

namespace ConvertTool.ViewModels
{
    public class LoginMainViewModel:ViewModelBase
    {

        private Constants.LoginViewMode _viewMode = Constants.LoginViewMode.Login;
        public Constants.LoginViewMode ViewMode
        {
            set
            {
                SetProperty(ref _viewMode, value);
                RaisePropertyChanged(nameof(LoginMainViewModel));
            }
            get => _viewMode;
        }

        private LoginViewModel _loginViewModel;
        public LoginViewModel LoginViewModel
        {
            set => SetProperty(ref _loginViewModel, value);
            get => _loginViewModel;
        }

        private RegisterViewModel _registerViewModel;
        public RegisterViewModel RegisterViewModel
        {
            set => SetProperty(ref _registerViewModel, value);
            get => _registerViewModel;
        }


        protected override void RegisterProperties()
        {
            base.RegisterProperties();
            LoginViewModel = new LoginViewModel(this);
            RegisterViewModel = new RegisterViewModel(this);
        }

        protected override void Init()
        {
            Title = "登录系统";
        }

    }
}