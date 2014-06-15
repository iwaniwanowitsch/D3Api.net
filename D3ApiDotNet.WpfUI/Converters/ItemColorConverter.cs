using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class ItemColorConverter : IValueConverter
    {
        private readonly Dictionary<string, Color?> _lookupDictionary = new Dictionary<string, Color?>
        {
            {"grey" , Application.Current.Resources["ItemBackgroundColorGrey"] as Color? },
            {"white", Application.Current.Resources["ItemBackgroundColorWhite"] as Color? },
            {"blue", Application.Current.Resources["ItemBackgroundColorBlue"] as Color? },
            {"yellow", Application.Current.Resources["ItemBackgroundColorYellow"] as Color? },
            {"orange", Application.Current.Resources["ItemBackgroundColorOrange"] as Color? },
            {"green", Application.Current.Resources["ItemBackgroundColorGreen"] as Color? }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value as string;
            if (value != null)
            {
                return new SolidColorBrush(_lookupDictionary[color].Value);
            }
            return new SolidColorBrush(_lookupDictionary["white"].Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
