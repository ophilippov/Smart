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
    /// A conerter that takes a bool and returns a Thickness (margin) value
    /// For PasswordBox attached property inside triggers issue
    /// </summary>
    public class BoolToMarginValueConverter : BaseValueConverter<BoolToMarginValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? new Thickness(0, 0, 0, -5): new Thickness(4, 5, 5, 1);
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
