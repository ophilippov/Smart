using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Smart.Core;

namespace Smart
{
    /// <summary>
    /// A conerter that takes a <see cref="DiscountType"/> and return a visibility value
    /// </summary>
    public class DiscountTypeToVisibilityValueConverter : BaseValueConverter<DiscountTypeToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return null;
            var par = Int32.Parse(parameter as string);
            var val = (int)((DiscountType)value);
            if (par == val)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
