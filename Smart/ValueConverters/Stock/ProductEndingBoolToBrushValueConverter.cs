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
    /// Converts the <see cref="bool"/> to a SolidColorBrush 
    /// If value is false parameter return blue, otherwise return red
    /// </summary>
    public class ProductEndingBoolToBrushValueConverter : BaseValueConverter<ProductEndingBoolToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((bool)value)
                return (SolidColorBrush)App.Current.Resources["DarkRedBrush"];
            else
                return (SolidColorBrush)App.Current.Resources["SemiDarkBlueBrush"];
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
