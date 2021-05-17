

using System;
using System.ComponentModel;
using Common.ViewModels;
using Common.Views;
using Microsoft.Practices.ServiceLocation;
using Prism.Ioc;
using Prism.Services.Dialogs;

namespace Common.Utility
{
    public class MessageUtility
    {
        public static bool? ShowMessage(string msg)
        {
            var container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            var dialogService = container?.Resolve<IDialogService>();
            var result = false;
            var param = new DialogParameters {{"message", msg}, {"title", "tips"}};
            dialogService?.ShowDialog("MessageView", param, o =>
            {
                if (o.Result == ButtonResult.OK)
                {
                    result = true;
                }
            });

            return result;
        }
    }
}