using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Common.Convertor
{
    public class BoolToVisibilityConvertor:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var back = parameter is string temp && temp == "back";
            if (back)
            {

                if (value is bool isDisplay && isDisplay)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
            else
            {
                if (value is bool isDisplay && isDisplay)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && visibility == Visibility.Visible)
            {
                return true;
            }

            return false;
        }
    }
}