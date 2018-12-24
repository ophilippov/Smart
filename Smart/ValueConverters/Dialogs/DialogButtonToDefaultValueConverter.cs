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
    /// A converter that takes a <see cref="DialogDefaultButton"/> and returns boolean value for each button
    /// </summary>
    public class DialogButtonToDefaultValueConverter : BaseValueConverter<DialogButtonToDefaultValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If we have no parameter, return
            if (parameter == null)
                return null;

            var par = (DialogDefaultButton)System.Convert.ToInt32(parameter);

            var val = (DialogDefaultButton)value;

            
            if (par == val) return true;
            else return false;
            
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
