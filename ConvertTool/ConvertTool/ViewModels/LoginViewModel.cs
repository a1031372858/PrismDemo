﻿using System.ComponentModel;
using System.Linq;
using System.Windows;
using Common.Bases;
using Common.Enums;
using Common.Utility;
using Common.Views;
using ConvertTool.Views;
using Games.Views;
using Prism.Commands;
using Prism.Ioc;
using SqlData;

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
                    ErrorsContainer.SetErrors(()=>Account,new string[]{ "用户名不能为空" });
                }
                else
                {
                    ErrorsContainer.ClearErrors(()=>Account);
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
            MessageUtility.ShowMessage(msg);
        }

        private void Register()
        {
            // ParentViewModel.DisplayLogin = Visibility.Collapsed;
            ParentViewModel.ViewMode = Constants.LoginViewMode.Register;
        }

        private void Login()
        {
            if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
            {
                var context = Container.Resolve<PostgreSqlContext>();
                var userList = context.UserDetail.ToList();
                if (userList.Any(o => o.Phone == Account && o.UserPassword == Password))
                {
                    Container.Resolve<SnakeView>().Show();
                    Container.Resolve<LoginMainView>().Close();
                }
                

                // string sql = string.Format("select * from \"user\" where phone= '{0}' and \"password\"='{1}'", Account, Password);

                // var result=SQLUtility.SqlExecute(sql);
                // if (result!=null&&result.HasRows&& result.Read())
                // {
                //     var name = result["username"];
                //     var id =result.GetData(1);
                // }
                // var loginView = Container.Resolve(typeof(ToolView));
                // if (loginView is ToolView view)
                // {
                //     view.Close();
                // }
            }
        }
        private void UpdatePassword()
        {

            Container.Resolve<UpdatePasswordView>().ShowDialog();
        }
    }
}