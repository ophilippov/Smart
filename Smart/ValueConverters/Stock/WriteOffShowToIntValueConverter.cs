﻿using Smart.Core;
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
    /// Converts a <see cref="WriteOffShow"/> to int value
    /// and int value back to the <see cref="WriteOffShow"/>
    /// </summary>
    public class WriteOffShowToIntValueConverter : BaseValueConverter<WriteOffShowToIntValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return int value
            return (int)((WriteOffShow)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Return SupplyShow value
            return (WriteOffShow)((int)value);
        }
    }
}
