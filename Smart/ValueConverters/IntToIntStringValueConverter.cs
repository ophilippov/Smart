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
    /// A conerter that takes a int and returns string with this value and string passed to the parameter
    /// For example:
    /// parameter: intValue
    /// </summary>
    public class IntToIntStringValueConverter : BaseValueConverter<IntToIntStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int)value;
            var par = parameter as string;

            if (par == null) return (int)value;
            else
                return $"{par}: {val}";
           
            }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
