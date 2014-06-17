using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class BoolToHardcoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hardcore = value as bool?;
            if (hardcore != null) {
                if (targetType == typeof(Brush))
                {
                    var color = hardcore.Value ? Colors.Red : Colors.Silver;
                    return new SolidColorBrush(color);
                }
                return hardcore.Value ? "Hardcore" : "Softcore";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
