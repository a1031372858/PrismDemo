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
    /// ToolView.xaml 的交互逻辑
    /// </summary>
    public partial class ToolView : Window
    {
        public ToolView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (HeaderView.DataContext is HeaderViewModel headerViewModel)
            {

            }
        }
    }
}
