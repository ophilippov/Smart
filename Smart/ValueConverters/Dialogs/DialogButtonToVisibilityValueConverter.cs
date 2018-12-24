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
    /// A converter that takes a <see cref="DialogButton"/> 
    /// and returns a <see cref="Visibility"/> for each button
    /// </summary>
    public class DialogButtonToVisibilityValueConverter : BaseValueConverter<DialogButtonToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If we have no parameter, return
            if (parameter == null)
                return null;

            var par = System.Convert.ToInt32(parameter);

            var val = (DialogButton)value;

            if ((val == DialogButton.Ok && par == 0) ||
                    (val == DialogButton.OkCancel && (par == 0 || par == 1)) ||
                    (val == DialogButton.YesNo && (par == 2 || par == 3)) ||
                    (val == DialogButton.YesNoCancel && (par == 2 || par == 3 || par == 1)) ||
                    (val == DialogButton.OkMore && (par == 0 || par == 4)) ||
                    (val == DialogButton.OkCancelMore && (par == 0 || par == 1 || par == 4)) ||
                    (val == DialogButton.YesNoMore && (par == 2 || par == 3 || par == 4)) ||
                    (val == DialogButton.YesNoCancelMore && (par == 2 || par == 3 || par == 1 || par == 4)))
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
           
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
