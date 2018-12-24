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
    public class BoolToGridRowValueConverter : BaseValueConverter<BoolToGridRowValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0 : 1;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
