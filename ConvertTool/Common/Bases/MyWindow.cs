using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Common.Bases
{
    public class MyWindow : Window
    {
        public static readonly DependencyProperty MaxButtonVisibilityProperty = DependencyProperty.Register(
            "MaxButtonVisibility", typeof(Visibility), typeof(MyWindow), new PropertyMetadata(Visibility.Collapsed));

        public Visibility MaxButtonVisibility
        {
            get => (Visibility) GetValue(MaxButtonVisibilityProperty);
            set => SetValue(MaxButtonVisibilityProperty, value);
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (GetTemplateChild("Header") is DockPanel header)
            {
                header.MouseMove += Header_OnMouseMove;
            }

            if (GetTemplateChild("MinButton") is Button minButton)
            {
                minButton.Click += MinButton_OnClick;
            }

            if (GetTemplateChild("CloseButton") is Button closeButton)
            {
                closeButton.Click += CloseButton_Click;
            }
            if (GetTemplateChild("BlackMessageBox") is Thumb blackMessageBox)
            {
                blackMessageBox.DragDelta += BlackMessageBox_OnDragDelta;
            }
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
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



        private void MinButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Header_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}