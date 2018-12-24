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
    /// A conerter that takes a <see cref="DialogButtonText"/> 
    /// and returns a string for required parameter
    /// </summary>
    public class DialogButtonTextToStringValueConverter : BaseValueConverter<DialogButtonTextToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (parameter == null)
                return null;

            var val = value as DialogButtonText;
            if (val == null)
                return null;


            int par = System.Convert.ToInt32(parameter);

            switch (par)
            {
                case 0: return val.OKText;
                case 1: return val.CancelText;
                case 2: return val.YesText;
                case 3: return val.NoText;
                case 4: return val.MoreText;
                default: return null;
            }
            
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
