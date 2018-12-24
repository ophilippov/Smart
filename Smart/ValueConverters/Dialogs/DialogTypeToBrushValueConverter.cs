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
    /// A conerter that takes a <see cref="DialogType"/> and returns a brush for specific type
    /// </summary>
    public class DialogTypeToBrushValueConverter : BaseValueConverter<DialogTypeToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (DialogType)value;

            if (val == DialogType.Exclamation || val == DialogType.Warning)
                return (SolidColorBrush)Application.Current.Resources["DarkRedBrush"];
            else if (val == DialogType.Success)
                return (SolidColorBrush)Application.Current.Resources["DarkGreenBrush"];
            else
                return (SolidColorBrush)Application.Current.Resources["DarkBlueBrush"];
            
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
