using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using D3ApiDotNet.Core.Objects.Hero;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class HeroClassIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var heroClass = value is HeroClass ? ((HeroClass)value).ToString() : "Default";
            var image = Application.Current.Resources["HeroClassImage" + heroClass] as BitmapImage;
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
