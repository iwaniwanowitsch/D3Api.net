using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using D3ApiDotNet.Core.Objects.Hero;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class HeroClassIconConverter : IValueConverter
    {
        private readonly Dictionary<HeroClass, Bitmap> _lookupDictionary = new Dictionary<HeroClass, Bitmap>
        {
            {HeroClass.Barbarian , Properties.Resources.BarbarianClassLogo32 },
            {HeroClass.Crusader , Properties.Resources.logo32 },
            {HeroClass.Demonhunter , Properties.Resources.logo32 },
            {HeroClass.Monk , Properties.Resources.logo32 },
            {HeroClass.Witchdoctor, Properties.Resources.WitchDoctorClassLogo32 },
            {HeroClass.Wizard, Properties.Resources.WizardClassLogo32 }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = value is HeroClass ? _lookupDictionary[(HeroClass)value] : Properties.Resources.logo32;
            return new ImageBitmapSourceConverter().Convert((Image)image, typeof(BitmapImage), null, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
