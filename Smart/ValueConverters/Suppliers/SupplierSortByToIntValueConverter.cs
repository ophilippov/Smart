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
    /// Converts a <see cref="SupplierSortBy"/> to int value
    /// and int value back to the <see cref="SupplierSortBy"/>
    /// </summary>
    public class SupplierSortByToIntValueConverter : BaseValueConverter<SupplierSortByToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((SupplierSortBy)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return SupplierSortBy value
            return (SupplierSortBy)((int)value);
        }
    }
}
