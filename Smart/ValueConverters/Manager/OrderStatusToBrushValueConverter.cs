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
    /// Converts the <see cref="OrderStatus"/> to a SolidColorBrush according to OrderStatus.Closed
    /// </summary>
    public class OrderStatusToBrushValueConverter : BaseValueConverter<OrderStatusToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((OrderStatus)value)
            {
                case OrderStatus.Closed: return (SolidColorBrush)Application.Current.Resources["OrdersListItemClosedBrush"];
                default: return (SolidColorBrush)(new BrushConverter().ConvertFromString("Transparent"));
            }
            throw new ArgumentException("Invailid order status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
