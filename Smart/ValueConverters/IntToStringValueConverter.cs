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
    /// A conerter that takes a int and returns string for a mask:
    /// 100 = 100
    /// 1200 = 1.2K
    /// 1200000 = 1.2M
    /// and uses Math.Round to round to dozens
    /// </summary>
    public class IntToStringValueConverter : BaseValueConverter<IntToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = (int)value;

            if (val < 1000)
                return $"{val}";
            else if (val > 1000 && val < 1000000)
                return $"{Math.Round((val / 1000), 1)}K";
            else
                return $"{Math.Round((val / 1000000),1)}M";
            }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
