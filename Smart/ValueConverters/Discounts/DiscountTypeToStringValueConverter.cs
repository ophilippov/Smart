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
    /// A conerter that takes a <see cref="DiscountType"/> and returns a string with a description
    /// </summary>
    public class DiscountTypeToStringValueConverter : BaseValueConverter<DiscountTypeToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (DiscountType)value;
            if (val == DiscountType.ProductGift || val == DiscountType.ProductPercentAll || val == DiscountType.ProductPercentOne)
                return "Скидка на товар";
            else
                return "Скидка на заказ";
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
