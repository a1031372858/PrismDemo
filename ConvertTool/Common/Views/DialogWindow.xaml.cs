using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common.Bases;
using Prism.Services.Dialogs;

namespace Common.Views
{
    /// <summary>
    /// DialogWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DialogWindow : IDialogWindow
    {
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result",
            typeof(IDialogResult), typeof(DialogWindow), new PropertyMetadata(null));

        public DialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result
        {
            get => (IDialogResult)GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }


        private void Header_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void BlackMessageBox_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb thumb && thumb.Parent is Canvas canvas)
            {
                var leftLength = Canvas.GetLeft(thumb) + e.HorizontalChange;
                if (leftLength < 0)
                {
                    leftLength = 0;
                }
                else if (leftLength > canvas.ActualWidth - thumb.ActualWidth)
                {
                    leftLength = canvas.ActualWidth - thumb.ActualWidth;
                }

                var topLength = Canvas.GetTop(thumb) + e.VerticalChange;
                if (topLength < 0)
                {
                    topLength = 0;
                }
                else if (topLength > canvas.ActualHeight - thumb.ActualHeight)
                {
                    topLength = canvas.ActualHeight - thumb.ActualHeight;
                }

                Canvas.SetLeft(thumb, leftLength);
                Canvas.SetTop(thumb, topLength);
            }
        }


        private void MessageCloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button closeBtn && closeBtn.TemplatedParent is Thumb thumb)
            {
                thumb.Visibility = Visibility.Collapsed;
            }
        }

        private void BlackMessageBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is FrameworkElement element && element.TemplatedParent is Thumb thumb && e.Key == Key.Escape)
            {
                thumb.Visibility = Visibility.Collapsed;
            }
        }

        private void BlackMessageBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is Thumb thumb)
            {

            }
        }
    }
}
