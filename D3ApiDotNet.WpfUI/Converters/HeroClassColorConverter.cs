using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using D3ApiDotNet.Core.Objects.Hero;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class HeroClassColorConverter : IValueConverter
    {
        private Color GetDefaultForegroundColor(Color fallbackColor)
        {
            var defaultBrush = Application.Current.Resources["TextBrush"] as SolidColorBrush;
            return defaultBrush != null ? defaultBrush.Color : fallbackColor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var heroClass = value is HeroClass ? (HeroClass)value : (HeroClass?)null;
            var color = Application.Current.Resources["HeroClassColor" + heroClass] as Color? ?? GetDefaultForegroundColor(Colors.Gray);
            
            if (targetType == typeof(Color))
                return new SolidColorBrush(color);
            if (targetType == typeof(Brush))
                return new SolidColorBrush(color);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
