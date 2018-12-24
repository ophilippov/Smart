using Smart.Core;
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
    /// Converts a <see cref="StockCategory"/> to a visibility value taking into account passed parameter
    /// </summary>
    public class StockCategoryToVisibilityValueConverter : BaseValueConverter<StockCategoryToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
                return null;

            var par = Int32.Parse(parameter as string);
            var val = (int)((StockCategory)value);

            if (par == val)
                return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
