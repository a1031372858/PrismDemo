using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConvertTool.ViewModels;

namespace ConvertTool.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginMainView : Window
    {

        public LoginMainView()
        {
            InitializeComponent();
        }

        private void PhoneTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                // PasswordTextBox.Focus();
                e.Handled = true;
            }
        }

        private void PasswordTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // LoginButton.Focus();
                if (DataContext is LoginViewModel vm && vm.LoginCommand.CanExecute())
                {
                    vm.LoginCommand.Execute();
                }
                e.Handled = true;
            }
        }

    }
}
