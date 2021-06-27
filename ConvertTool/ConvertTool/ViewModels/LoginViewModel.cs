using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Common.Bases;
using Common.Enums;
using Common.Global;
using Common.Utility;
using Common.Views;
using ConvertTool.Views;
using Games.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using SqlData;
using SqlData.Beans;

namespace ConvertTool.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginMainViewModel ParentViewModel;

        public LoginViewModel() { }

        public LoginViewModel(LoginMainViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        private string _account = string.Empty;
        public string Account
        {
            set
            {
                SetProperty(ref _account, value);
                if (string.IsNullOrEmpty(_account))
                {
                    ErrorsContainer.SetErrors(() => Account, new string[] { "用户名不能为空" });
                }
                else
                {
                    ErrorsContainer.ClearErrors(() => Account);
                }
            }
            get => _account;
        }

        private string _password = string.Empty;
        public string Password
        {
            set => SetProperty(ref _password, value);
            get => _password;
        }

        public DelegateCommand LoginCommand { set; get; }

        public DelegateCommand RegisterCommand { set; get; }

        public DelegateCommand UpdatePasswordCommand { set; get; }
        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            LoginCommand = new DelegateCommand(Login);
            RegisterCommand = new DelegateCommand(Register);
            UpdatePasswordCommand = new DelegateCommand(UpdatePassword);
        }


        protected override void RegisterEvents()
        {
            base.RegisterEvents();
            ErrorsChanged += LoginViewModel_ErrorsChanged;
        }

        private void LoginViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var msg = ErrorsContainer.GetErrors(e.PropertyName).FirstOrDefault();
            ParentViewModel.ShowMessage(msg);
        }

        private void Register()
        {
            ParentViewModel.ViewMode = Constants.LoginViewMode.Register;
        }

        private void Login()
        {
            if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
            {
                if (!RedisUtility.Client.IsSocketConnected())
                {
                    return;
                }
                    
                var loginUser = RedisUtility.Client.Get<UserDetail>(Account);
                if (loginUser != null)
                {
                    if (loginUser.UserPassword == Password)
                    {
                        ParentViewModel.ShowMessage("登录成功！");
                        GlobalData.LoginUserInfo.UserDetail = loginUser;
                        DialogService.Show("GamesView");
                    }
                    else
                    {
                        ParentViewModel.ShowMessage("用户名或密码错误！");
                    }
                }
                else
                {
                    ParentViewModel.ShowMessage("该用户不存在！");
                }
            } 
            else
            {
                ParentViewModel.ShowMessage("用户名或密码不能为空！");
            }


            // if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
            // {
            //     var context = Container.Resolve<PostgreSqlContext>();
            //     try
            //     {
            //         if (!await context.Database.CanConnectAsync())
            //         {
            //             ParentViewModel.ShowMessage("连接数据库失败");
            //             return;
            //         }
            //
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e);
            //         ParentViewModel.ShowMessage("连接数据库失败");
            //         return;
            //     }
            //
            //     var loginUser = context.UserDetail.FirstOrDefault(o => o.Phone == Account);
            //     if (loginUser != null)
            //     {
            //         if (loginUser.UserPassword == Password)
            //         {
            //             ParentViewModel.ShowMessage("登录成功！");
            //             GlobalData.LoginUserInfo.UserDetail = loginUser;
            //             DialogService.Show("GamesView");
            //         }
            //         else
            //         {
            //             ParentViewModel.ShowMessage("用户名或密码错误！");
            //         }
            //     }
            //     else
            //     {
            //         ParentViewModel.ShowMessage("该用户不存在！");
            //     }
            // }
            // else
            // {
            //     ParentViewModel.ShowMessage("用户名或密码不能为空！");
            // }
        }
        private void UpdatePassword()
        {
            ParentViewModel.ViewMode = Constants.LoginViewMode.UpdatePsw;
        }
    }
}