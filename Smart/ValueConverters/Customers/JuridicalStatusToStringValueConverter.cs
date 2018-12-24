using Smart.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Smart
{
    /// <summary>
    /// Converts the <see cref="JuridicalStatus"/> to a strinfg
    /// </summary>
    public class JuridicalStatusToStringValueConverter : BaseValueConverter<JuridicalStatusToStringValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            switch ((JuridicalStatus)value)
            {
                case JuridicalStatus.Artificial: return "юр. лицо";
                case JuridicalStatus.Individual: return "физ. лицо";
                default: break;
            }
            throw new ArgumentException("Invailid juridical status");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
