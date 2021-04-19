using System;
using System.Data.SqlClient;
using System.Windows;
using Common.Bases;
using Npgsql;
using Prism.Commands;

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

        private void Register()
        {
            string dataSource = @"PORT=5432;DATABASE=usermanager;HOST=localhost;PASSWORD=666666;USER ID=postgres;";
            if(Password!=CheckPassword||string.IsNullOrEmpty(Password)||string.IsNullOrEmpty(Phone))return;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(dataSource))
                {
                    connection.Open();
                    var sql = string.Format("insert into \"user\" VALUES(123457,'{0}','{1}','{0}','1',50,'{0}')", Phone,Password);
                    NpgsqlCommand command = new NpgsqlCommand(sql,connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {

            }
            
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