using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Smart.Core;
using System.Windows.Media;

namespace Smart
{
    /// <summary>
    /// A conerter that takes a <see cref="DialogType"/> and returns a FontAwesome icon as unicode symbol
    /// </summary>
    public class DialogTypeToIconValueConverter : BaseValueConverter<DialogTypeToIconValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DialogType)value).ToIcon();

        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
