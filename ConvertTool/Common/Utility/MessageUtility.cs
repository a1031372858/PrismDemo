

using System.ComponentModel;
using Common.ViewModels;
using Common.Views;
using Microsoft.Practices.ServiceLocation;
using Prism.Ioc;

namespace Common.Utility
{
    public class MessageUtility
    {
        public static bool? ShowMessage(string msg)
        {
            var container = ServiceLocator.Current.GetInstance<IContainerProvider>();
            var view = container.Resolve<MessageView>();
            if (view.DataContext is MessageViewModel vm)
            {
                vm.Message = msg;
            }

            return view.ShowDialog();
        }
    }
}