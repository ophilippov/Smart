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
    /// Converts the <see cref="PaymentStatus"/> to the normal string
    /// </summary>
    public class PaymentStatusToStringValueConverter : BaseValueConverter<PaymentStatusToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each payment`s status
            switch ((PaymentStatus)value)
            {
                case PaymentStatus.Paid: return "оплачено";
                case PaymentStatus.PaidForPart: return "оплачено частично";
                case PaymentStatus.WaitingForPayment: return "ожидается оплата";
                case PaymentStatus.Overdue: return "платеж просрочен";
                case PaymentStatus.ReturningMoney: return "возврат средств";
                default: Debugger.Break(); break;
            }
            throw new ArgumentException("Invailid payment status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
