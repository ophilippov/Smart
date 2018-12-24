using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Smart.Core;

namespace Smart
{
    /// <summary>
    /// A conerter that takes a <see cref="DiscountType"/> and returns the MD icon
    /// </summary>
    public class DiscountTypeToIconValueConverter : BaseValueConverter<DiscountTypeToIconValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (DiscountType)value;
            if (val == DiscountType.ProductGift || val == DiscountType.ProductPercentAll || val == DiscountType.ProductPercentOne)
                return App.Current.Resources["MDBoxIcon"];
            else
                return App.Current.Resources["MDCartIcon"];
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
