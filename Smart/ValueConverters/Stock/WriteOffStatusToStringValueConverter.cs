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
    /// Converts the <see cref="WriteOffStatus"/> to the normal string
    /// </summary>
    public class WriteOffStatusToStringValueConverter : BaseValueConverter<WriteOffStatusToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each write-off`s status
            switch ((WriteOffStatus)value)
            {
                case WriteOffStatus.Cancelled: return "отменено";
                case WriteOffStatus.Done: return "выполнено";
                case WriteOffStatus.NewWriteOff: return "новое списание";
                default: Debugger.Break(); break;
            }
            throw new ArgumentException("Invailid write-off status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
