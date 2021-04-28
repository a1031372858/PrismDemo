using System.Windows;

namespace Common.Bases
{
    public class MyWindow : Window
    {
        public static readonly DependencyProperty MaxButtonVisibilityProperty = DependencyProperty.Register(
            "MaxButtonVisibility", typeof(Visibility), typeof(MyWindow), new PropertyMetadata(Visibility.Collapsed));

        public Visibility MaxButtonVisibility
        {
            get => (Visibility)GetValue(MaxButtonVisibilityProperty);
            set => SetValue(MaxButtonVisibilityProperty, value);
        }


    }
}