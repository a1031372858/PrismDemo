using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using Common.Bases;
using Common.ViewModels;
using Common.Views;
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

        private LoginMainViewModel ParentViewModel;
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

            var userList = context.UserDetail.ToList();
            if (userList.Any(o => o.Phone == Phone))
            {
                var view =Container.Resolve<MessageView>();
                if (view.DataContext is MessageViewModel vm)
                {
                    vm.Message = "该手机号已注册！";
                    view.ShowDialog();
                }
                // Console.WriteLine("该手机号已注册！");
                return;
            }

            var newUserId = userList.Max(o => o.UserId);
            newUserId++;
            if (Password != CheckPassword || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Phone)) return;

            var user = new UserDetail
            {
                UserId = newUserId,
                Phone = Phone,
                UserPassword = Password,
                BirthDay = DateTime.MinValue,
                Sex = "1",
                CreateUser = "0",
                CreateDate = DateTime.Now,
                UpdateUser = "0",
                UpdateDate = DateTime.Now,
            };
           await context.UserDetail.AddAsync(user);
           await context.SaveChangesAsync();

           // string dataSource = @"PORT=5432;DATABASE=usermanager;HOST=localhost;PASSWORD=666666;USER ID=postgres;";
           // if(Password!=CheckPassword||string.IsNullOrEmpty(Password)||string.IsNullOrEmpty(Phone))return;
           // try
           // {
           //     using (NpgsqlConnection connection = new NpgsqlConnection(dataSource))
           //     {
           //         connection.Open();
           //         var sql = string.Format("insert into \"user\" VALUES(123457,'{0}','{1}','{0}','1',50,'{0}')", Phone,Password);
           //         NpgsqlCommand command = new NpgsqlCommand(sql,connection);
           //         command.ExecuteNonQuery();
           //     }
           // }
           // catch (Exception e)
           // {
           //     Console.WriteLine(e);
           //     throw;
           // }
           // finally
           // {
           //
           // }

        }

        private void Cancel()
        {
            if (ParentViewModel != null)
            {
                ParentViewModel.DisplayRegister = Visibility.Collapsed;
            }
        }
    }
}