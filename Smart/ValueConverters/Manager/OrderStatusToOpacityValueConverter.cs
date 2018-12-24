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
    /// Converts the <see cref="OrderStatus"/> to an Opacity double value for Orders content
    /// </summary>
    public class OrderStatusToOpacityValueConverter : BaseValueConverter<OrderStatusToOpacityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((OrderStatus)value)
            {
                case OrderStatus.Closed: return 0.6d;
                default: return 1d;
            }
            throw new ArgumentException("Invailid order status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
