using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Smart
{
    /// <summary>
    /// A converter that takes a <see cref="DateTime"/> and returns a string with date
    /// </summary>
    public class DateTimeToDateStringValueConverter : BaseValueConverter<DateTimeToDateStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = value as DateTime?;
            if (dateTime == null)
                return null;

            if ((dateTime.Value.Day / 10) == 0 && (dateTime.Value.Month / 10) == 0)
                return $"0{dateTime.Value.Day}.0{dateTime.Value.Month}.{dateTime.Value.Year}";
            else if ((dateTime.Value.Day / 10) == 0)
                return $"0{dateTime.Value.Day}.{dateTime.Value.Month}.{dateTime.Value.Year}";
            else if ((dateTime.Value.Month / 10) == 0)
                return $"{dateTime.Value.Day}.0{dateTime.Value.Month}.{dateTime.Value.Year}";
            else
                return $"{dateTime.Value.Day}.{dateTime.Value.Month}.{dateTime.Value.Year}";





        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
