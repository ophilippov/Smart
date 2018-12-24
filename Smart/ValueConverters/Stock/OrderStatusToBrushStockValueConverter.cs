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
    /// Converts the <see cref="OrderStatus"/> to a SolidColorBrush 
    /// </summary>
    public class OrderStatusToBrushStockValueConverter : BaseValueConverter<OrderStatusToBrushStockValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new brush for each order`s status
            switch ((OrderStatus)value)
            {
                case OrderStatus.StockProcessing: return (SolidColorBrush)Application.Current.Resources["DarkGreenBrush"];
                case OrderStatus.StockRejected: return (SolidColorBrush)Application.Current.Resources["DarkRedBrush"];
                default: return (SolidColorBrush)Application.Current.Resources["LightGreyBrush"]; ;
            }
            throw new ArgumentException("Invailid order status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
