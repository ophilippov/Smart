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
    /// Converts the <see cref="PaymentStatus"/> to the normal string
    /// </summary>
    public class PaymentStatusToBrushValueConverter : BaseValueConverter<PaymentStatusToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each payment`s status
            switch ((PaymentStatus)value)
            {
                //Dark Green Brush
                case PaymentStatus.Paid: return new SolidColorBrush((Color)Application.Current.Resources["DarkGreen"]);

                //Light Grey Brush
                case PaymentStatus.PaidForPart:return new SolidColorBrush((Color)Application.Current.Resources["LightGrey"]);

                //Light Grey Brush
                case PaymentStatus.WaitingForPayment: return new SolidColorBrush((Color)Application.Current.Resources["LightGrey"]);

                //Dark Red Brush
                case PaymentStatus.Overdue: return new SolidColorBrush((Color)Application.Current.Resources["DarkRed"]);

                //Light Grey Brush
                case PaymentStatus.ReturningMoney: return new SolidColorBrush((Color)Application.Current.Resources["LightGrey"]);

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
