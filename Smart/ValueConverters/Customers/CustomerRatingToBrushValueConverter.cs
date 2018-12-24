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
    /// Converts a customer string (as an int) to a brush
    /// </summary>
    public class CustomerRatingToBrushValueConverter : BaseValueConverter<CustomerRatingToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((int)value < 0)
                return (SolidColorBrush)Application.Current.Resources["DarkRedBrush"];
            else 
                return (SolidColorBrush) Application.Current.Resources["DarkGreenBrush"];
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
