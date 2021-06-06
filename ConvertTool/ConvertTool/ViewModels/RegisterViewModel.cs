using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Common.Bases;
using Common.Enums;
using Common.Utility;
using Common.ViewModels;
using Common.Views;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;
using Prism.Commands;
using Prism.Ioc;
using SqlData;
using SqlData.Beans;

namespace ConvertTool.ViewModels
{
    public class RegisterViewModel:ViewModelBase
    {

        private string _phone = string.Empty;
        public string Phone
        {
            set => SetProperty(ref _phone, value);
            get => _phone;
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

        public LoginMainViewModel ParentViewModel;
        public RegisterViewModel() { }

        public DelegateCommand CancelCommand { set; get; }
        public DelegateCommand RegisterCommand { set; get; }

        public RegisterViewModel(LoginMainViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        protected override void Init()
        {
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
        }

        protected override void RegisterCommands()
        {
            base.RegisterCommands();
            CancelCommand= new DelegateCommand(Cancel);
            RegisterCommand = new DelegateCommand(Register);
        }

        private async void Register()
        {
            var context = Container.Resolve<PostgreSqlContext>();
            try
            {

                if (context.UserDetail.Any(o => o.Phone == Phone))
                {
                    MessageUtility.ShowMessage("该手机号已注册！");
                    return;
                }

                var newUserId = 0;
                if (context.UserDetail.Any())
                {
                    newUserId = context.UserDetail.Max(o => o.UserId);
                }

                newUserId++;
                if (Password != CheckPassword || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Phone)) return;

                var user = new UserDetail
                {
                    UserId = newUserId,
                    Phone = Phone,
                    UserPassword = Password,
                    BirthDay = DateTime.MinValue,
                    Sex = "1",
                    CreateUser = 1,
                    CreateDate = DateTime.Now,
                    UpdateUser = 1,
                    UpdateDate = DateTime.Now,
                };
                await context.UserDetail.AddAsync(user);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageUtility.ShowMessage("数据库登录失败！");
            }
        }

        private void Cancel()
        {
            if (ParentViewModel != null)
            {
                ParentViewModel.ViewMode = Constants.LoginViewMode.Login;
            }
        }
    }
}