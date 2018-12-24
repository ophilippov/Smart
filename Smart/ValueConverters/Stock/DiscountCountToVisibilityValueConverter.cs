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
    /// Converts the <see cref="int"/> of number of discounts to a <see cref="Visibility"/>
    /// If > 0 return visible, otherwise return collapsed
    /// </summary>
    public class DiscountCountToVisibilityValueConverter : BaseValueConverter<DiscountCountToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((int)value > 0)
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
