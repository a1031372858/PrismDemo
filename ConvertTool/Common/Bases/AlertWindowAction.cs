using System;
using System.Windows;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Xaml.Behaviors;

namespace Common.Bases
{
    public class AlertWindowAction : TriggerAction<FrameworkElement>
    {
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