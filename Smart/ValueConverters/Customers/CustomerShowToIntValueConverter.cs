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
    /// Converts a <see cref="CustomerShow"/> to int value
    /// and int value back to the <see cref="CustomerShow"/>
    /// </summary>
    public class CustomerShowToIntValueConverter : BaseValueConverter<CustomerShowToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((CustomerShow)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return OrderSortByValue
            return (CustomerShow)((int)value);
        }
    }
}
