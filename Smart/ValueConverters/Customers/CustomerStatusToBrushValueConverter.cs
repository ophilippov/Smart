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
    /// Converts the <see cref="CustomerStatus"/> to a SolidColorBrush
    /// </summary>
    public class CustomerStatusToBrushValueConverter : BaseValueConverter<CustomerStatusToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((CustomerStatus)value)
            {
                case CustomerStatus.Inactive: return (SolidColorBrush)Application.Current.Resources["DarkRedBrush"];
                default: return (SolidColorBrush)Application.Current.Resources["LightGreyBrush"];
            }
            throw new ArgumentException("Invailid customer status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
