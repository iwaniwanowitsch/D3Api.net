using System;
using System.Globalization;
using System.Windows.Data;
using D3ApiDotNet.Core.Calculation.Formulas;

namespace D3ApiDotNet.WpfUI.Converters
{
    public class TermEvaluateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var term = value as ITerm;
            if (term != null)
                return term.Evaluate();
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
