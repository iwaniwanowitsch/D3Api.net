using System;
using System.Globalization;
using System.Windows.Data;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = value as bool?;
            if (visibility != null)
                return visibility.Value ? "Visible" : "Hidden";
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
