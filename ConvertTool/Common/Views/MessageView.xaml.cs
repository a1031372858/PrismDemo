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

namespace Common.Views
{
    /// <summary>
    /// MessageView.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageView : UserControl
    {

        public MessageView()
        {
            InitializeComponent();
        }

        private void MessageView_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModelBase vm)
            {
                // vm.OnDialogClosed();
            }
        }
    }
}
