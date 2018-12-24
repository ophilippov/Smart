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
    /// Converts first value of a <see cref="Thickness"/> to one value of a <see cref="GridLength"/> 
    /// </summary>
    public class MarginLeftToWidthValueConverter : BaseValueConverter<MarginLeftToWidthValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return new GridLength(((Thickness)value).Left);
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
