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
    /// Converts the <see cref="OrderStatus"/> to the normal string taking to
    /// an account we are in the Stock Page
    /// </summary>
    public class OrderStatusToStringStockValueConverter : BaseValueConverter<OrderStatusToStringStockValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((OrderStatus)value)
            {
                case OrderStatus.StockApproved: return "комплектуется";
                case OrderStatus.StockDepartured: return "отгружен со склада";
                case OrderStatus.StockProcessing: return "новый заказ";
                case OrderStatus.StockRejected: return "отклонен";
                case OrderStatus.TransferedToSC: return "передан в службу доставки";
                default: Debugger.Break(); break;
            }
            throw new ArgumentException("Invailid order status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
