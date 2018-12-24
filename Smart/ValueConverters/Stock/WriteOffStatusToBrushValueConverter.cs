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
    /// Converts the <see cref="WriteOffStatus"/> to the normal string
    /// </summary>
    public class WriteOffStatusToBrushValueConverter : BaseValueConverter<WriteOffStatusToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return a new string for each write-off`s status
            switch ((WriteOffStatus)value)
            {
                //Dark Green Brush
                case WriteOffStatus.NewWriteOff: return new SolidColorBrush((Color)Application.Current.Resources["DarkGreen"]);

                //Light Grey Brush
                case WriteOffStatus.Done: return new SolidColorBrush((Color)Application.Current.Resources["LightGrey"]);

                //Light Grey Brush
                case WriteOffStatus.Cancelled: return new SolidColorBrush((Color)Application.Current.Resources["DarkRed"]);

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
