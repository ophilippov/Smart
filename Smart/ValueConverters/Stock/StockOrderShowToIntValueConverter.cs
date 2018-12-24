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
    /// Converts a <see cref="StockOrderShow"/> to int value
    /// and int value back to the <see cref="StockOrderShow"/>
    /// </summary>
    public class StockOrderShowToIntValueConverter : BaseValueConverter<StockOrderShowToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((StockOrderShow)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return OrderSortByValue
            return (StockOrderShow)((int)value);
        }
    }
}
