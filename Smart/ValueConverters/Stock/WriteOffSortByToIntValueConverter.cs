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
    /// Converts a <see cref="WriteOffSortBy"/> to int value
    /// and int value back to the <see cref="WriteOffSortBy"/>
    /// </summary>
    public class WriteOffSortByToIntValueConverter : BaseValueConverter<WriteOffSortByToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((WriteOffSortBy)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return SupplySortBy value
            return (WriteOffSortBy)((int)value);
        }
    }
}
