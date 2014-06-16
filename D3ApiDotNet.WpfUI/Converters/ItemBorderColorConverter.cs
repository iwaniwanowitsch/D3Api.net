using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class ItemBorderColorConverter : IValueConverter
    {
        private readonly Dictionary<string, Style> _lookupDictionary = new Dictionary<string, Style>
        {
            {"gray" , Application.Current.FindResource("GrayItemBorderStyle") as Style},
            {"white", Application.Current.FindResource("WhiteItemBorderStyle") as Style},
            {"blue", Application.Current.FindResource("BlueItemBorderStyle") as Style},
            {"yellow", Application.Current.FindResource("YellowItemBorderStyle") as Style},
            {"orange", Application.Current.FindResource("OrangeItemBorderStyle") as Style},
            {"green", Application.Current.FindResource("GreenItemBorderStyle") as Style}
        }; 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value as string;
            if (color != null)
            {
                return _lookupDictionary[color];
            }
            return Application.Current.FindResource("WhiteItemBorderStyle") as Style;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
