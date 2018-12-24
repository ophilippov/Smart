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
    /// Converts a value of a <see cref="GridLength"/> to the negative left value of a <see cref="Thickness"/> 
    /// </summary>
    public class WidthToNegativeMarginLeftValueConverter : BaseValueConverter<WidthToNegativeMarginLeftValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return new Thickness(-(double)value, 0, 0, 0);
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
