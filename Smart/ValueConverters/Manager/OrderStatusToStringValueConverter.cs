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
    /// Converts the <see cref="OrderStatus"/> to the normal string
    /// </summary>
    public class OrderStatusToStringValueConverter : BaseValueConverter<OrderStatusToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((OrderStatus)value)
            {
                case OrderStatus.Cancelled: return "отменен";
                case OrderStatus.Closed: return "закрыт";
                case OrderStatus.Delivered: return "доставлен";
                case OrderStatus.Delivering: return "доставляется";
                case OrderStatus.Done: return "выполнен";
                case OrderStatus.ManagerProcessing: return "обрабатывается менеджером";
                case OrderStatus.NewOrder: return "новый заказ";
                case OrderStatus.StockApproved: return "комплектуется";
                case OrderStatus.StockDepartured: return "отгружен со склада";
                case OrderStatus.StockProcessing: return "обрабатывается складом";
                case OrderStatus.StockRejected: return "отклонен складом";
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
