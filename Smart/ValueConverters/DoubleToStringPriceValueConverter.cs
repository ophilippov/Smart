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
    /// A converter that takes a double and returns a string 
    /// with double rounded to hundredths
    /// </summary>
    public class DoubleToStringPriceValueConverter : BaseValueConverter<DoubleToStringPriceValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            //Round source value to hundredths
            var dbHundredths = Math.Round((double)value, 2);

            //Round value to decimals to make sure
            //we have two digits after dot
            var dbDecimals = Math.Round(dbHundredths, 1);

            //Round value to integers to make sure
            //we have two digits after dot
            var dbIntegers = Math.Round(dbHundredths, 0);

            //If we have two digits after dot
            if (dbHundredths != dbDecimals && dbDecimals != dbIntegers)
                return $"{dbHundredths}".Replace(',', '.');
            //If we have only one digit after dot
            else if (dbHundredths == dbDecimals && dbDecimals != dbIntegers)
                return $"{dbHundredths}0".Replace(',', '.');
            //If we haven't any digits after dot
            else
                return $"{dbHundredths}.00";



        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
