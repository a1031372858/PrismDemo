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

namespace Games.Views
{
    /// <summary>
    /// SnakeView.xaml 的交互逻辑
    /// </summary>
    public partial class SnakeView : Window
    {
        public SnakeView()
        {
            InitializeComponent();
        }

        private void SnakeView_OnLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                }
            }
        }
    }
}
