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
using Common.Bases;
using Common.Views;
using ConvertTool.ViewModels;

namespace ConvertTool.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginMainView : MyWindow
    {

        public LoginMainView()
        {
            InitializeComponent();
        }

        private void PhoneTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox&& textBox.Parent is FrameworkElement element)
                {
                    if (element.FindName("PasswordTextBox") is TextBox passwordTextBox)
                    {
                        passwordTextBox.Focus();
                    }
                }
                e.Handled = true;
            }
        }

        private void PasswordTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox && textBox.Parent is FrameworkElement element)
                {
                    if (element.FindName("LoginButton") is Button loginBtn)
                    {
                        loginBtn.Focus();
                    }
                }
                // LoginButton.Focus();
                if (DataContext is LoginMainViewModel vm && vm.LoginViewModel.LoginCommand.CanExecute())
                {
                    vm.LoginViewModel.LoginCommand.Execute();
                }
                e.Handled = true;
            }
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox && textBox.Parent is FrameworkElement element)
                {
                    if (element.FindName("PasswordTextBox") is TextBox passwordTextBox)
                    {
                        passwordTextBox.Focus();
                    }
                }
                e.Handled = true;
            }
        }

        private void PasswordTextBox2_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox && textBox.Parent is FrameworkElement element)
                {
                    if (element.FindName("CheckTextBox") is TextBox checkTextBox)
                    {
                        checkTextBox.Focus();
                    }
                }
                e.Handled = true;
            }
        }

        private void CheckTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox && textBox.Parent is FrameworkElement element)
                {
                    if (element.FindName("RegisterBtn") is Button registerBtn)
                    {
                        registerBtn.Focus();
                    }
                }
                e.Handled = true;
            }
        }
    }
}
