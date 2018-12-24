using Smart.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart
{
    /// <summary>
    /// Converts a <see cref="ProductShow"/> to int value
    /// and int value back to the <see cref="ProductShow"/>
    /// </summary>
    public class ProductShowToIntValueConverter : BaseValueConverter<ProductShowToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((ProductShow)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return OrderSortByValue
            return (ProductShow)((int)value);
        }
    }
}
