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
    /// Converts the <see cref="SupplyStatus"/> to the normal string
    /// </summary>
    public class SupplyStatusToStringValueConverter : BaseValueConverter<SupplyStatusToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each order`s status
            switch ((SupplyStatus)value)
            {
                case SupplyStatus.Cancelled: return "отменена";
                case SupplyStatus.Done: return "выполнена";
                case SupplyStatus.NewSupply: return "новая поставка";
                case SupplyStatus.Waiting: return "ожидается";
                default: Debugger.Break(); break;
            }
            throw new ArgumentException("Invailid supply status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
