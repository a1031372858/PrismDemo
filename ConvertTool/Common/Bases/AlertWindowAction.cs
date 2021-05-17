using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System;
using System.Reflection;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using Prism.Common;

namespace Common.Bases
{
    public class AlertWindowAction : TriggerAction<FrameworkElement>
    {
        public static readonly DependencyProperty WindowNameProperty = DependencyProperty.Register("WindowName",
            typeof(string), typeof(AlertWindowAction), new PropertyMetadata(string.Empty));

        public string WindowName
        {
            get => (string)GetValue(WindowNameProperty);
            set => SetValue(WindowNameProperty, value);
        }


        protected override void Invoke(object parameter)
        {
            if (!(parameter is InteractionRequestedEventArgs arg))
                return;

            var windows = this.GetChildWindow(arg.Context);

            var callback = arg.Callback;
            EventHandler handler = null;
            handler =
                (o, e) =>
                {
                    windows.Closed -= handler;
                    callback();
                };
            windows.Closed += handler;
        }
        Window GetChildWindow(INotification notification)
        {
            if (!string.IsNullOrEmpty(WindowName))
            {
                var obj =Assembly.Load(WindowName);
            }

            var childWindow = this.CreateDefaultWindow(notification);
            childWindow.DataContext = notification;

            return childWindow;
        }

        Window CreateDefaultWindow(INotification notification)
        {
            return (Window)new Window();
        }
    }
}