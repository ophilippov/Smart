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
    /// Converts a <see cref="CustomerSortBy"/> to int value
    /// and int value back to the <see cref="CustomerSortBy"/>
    /// </summary>
    public class CustomerSortByToIntValueConverter : BaseValueConverter<CustomerSortByToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((CustomerSortBy)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return CustomerSortBy value
            return (CustomerSortBy)((int)value);
        }
    }
}
