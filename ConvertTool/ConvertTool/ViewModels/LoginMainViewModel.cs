using System.Windows;
using Common.Bases;
using Common.Enums;
using ConvertTool.Views;
using Prism.Commands;

namespace ConvertTool.ViewModels
{
    public class LoginMainViewModel:ViewModelBase
    {

        private Constants.LoginViewMode _viewMode = Constants.LoginViewMode.Login;
        public Constants.LoginViewMode ViewMode
        {
            set => SetProperty(ref _viewMode, value);
            get => _viewMode;
        }

        private Visibility _displayLogin = Visibility.Visible;
        public Visibility DisplayLogin
        {
            set
            {
                SetProperty(ref _displayLogin, value);
                if (_displayLogin == Visibility.Collapsed)
                {
                    _displayRegister = Visibility.Visible;
                }else if (_displayLogin == Visibility.Visible)
                {
                    _displayRegister = Visibility.Collapsed;
                }
                RaisePropertyChanged(nameof(DisplayRegister));
            }
            get => _displayLogin;
        }

        private Visibility _displayRegister = Visibility.Collapsed;
        public Visibility DisplayRegister
        {
            set
            {
                SetProperty(ref _displayRegister, value);
                if (_displayRegister == Visibility.Collapsed)
                {
                    _displayLogin = Visibility.Visible;
                }
                else if (_displayRegister == Visibility.Visible)
                {
                    _displayLogin = Visibility.Collapsed;
                }
                RaisePropertyChanged(nameof(DisplayLogin));
            }
            get => _displayRegister;
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