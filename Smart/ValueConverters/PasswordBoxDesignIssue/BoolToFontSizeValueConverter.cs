using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Smart
{
    /// <summary>
    /// A conerter that takes a bool and returns a FontSize value
    /// For PasswordBox attached property inside triggers issue
    /// </summary>
    public class BoolToFontSizeValueConverter : BaseValueConverter<BoolToFontSizeValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.Resources["FontSizeSmall"] : Application.Current.Resources["FontSizeRegular"];
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
