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
    public class AffixTypeColorConverter : IValueConverter
    {
        private readonly Dictionary<string, Color?> _lookupDictionary = new Dictionary<string, Color?>
        {
            {"default" , Application.Current.Resources["ItemBackgroundColorGray"] as Color? },
            {"utility", Application.Current.Resources["ItemBackgroundColorOrange"] as Color? },
            {"enchant", Application.Current.Resources["ItemBackgroundColorBlue"] as Color? }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var affix = value as string;
            if (affix != null)
            {
                var color = _lookupDictionary[affix];
                if (color != null) return new SolidColorBrush(color.Value);
            }
            return new SolidColorBrush(_lookupDictionary["default"].Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
