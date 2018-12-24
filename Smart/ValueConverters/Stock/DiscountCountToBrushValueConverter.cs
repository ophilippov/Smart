using Smart.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Smart
{
    /// <summary>
    /// Converts the <see cref="int"/> of number of discounts to a SolidColorBrush 
    /// If > 0 return green, otherwise return grey
    /// </summary>
    public class DiscountCountToBrushValueConverter : BaseValueConverter<DiscountCountToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((int)value > 0)
                return (SolidColorBrush)App.Current.Resources["DarkGreenBrush"];
            else
                return (SolidColorBrush)App.Current.Resources["LightGreyBrush"];
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
