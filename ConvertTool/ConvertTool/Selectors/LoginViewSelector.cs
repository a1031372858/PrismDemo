using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Common.Enums;
using ConvertTool.ViewModels;

namespace ConvertTool.Selectors
{
    public class LoginViewSelector : DataTemplateSelector
    {
        public DataTemplate LoginTemplate { set; get; }
        public DataTemplate RegisterTemplate { set; get; }
        public DataTemplate UpdatePsdTemplate { set; get; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is LoginMainViewModel vm)
            {
                var loginViewMode = vm.ViewMode;
                switch (loginViewMode)
                {
                    case Constants.LoginViewMode.Login:
                        return LoginTemplate;
                    case Constants.LoginViewMode.Register:
                        return RegisterTemplate;
                    case Constants.LoginViewMode.UpdatePsw:
                        return UpdatePsdTemplate;
                    default:
                        return LoginTemplate;
                }
            }

            return LoginTemplate;
        }
    }
}