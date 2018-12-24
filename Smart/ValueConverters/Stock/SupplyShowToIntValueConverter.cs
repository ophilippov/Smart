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
    /// Converts a <see cref="SupplyShow"/> to int value
    /// and int value back to the <see cref="SupplyShow"/>
    /// </summary>
    public class SupplyShowToIntValueConverter : BaseValueConverter<SupplyShowToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((SupplyShow)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return SupplyShow value
            return (SupplyShow)((int)value);
        }
    }
}
