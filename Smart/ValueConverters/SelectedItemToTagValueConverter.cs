using Smart.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Smart
{
    /// <summary>
    /// Converts a SelectedItem to the normal string of its Tag
    /// </summary>
    public class SelectedItemToTagValueConverter : BaseValueConverter<SelectedItemToTagValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //If we have nothing, return default
            if (value == null)
                return App.Current.Resources["MDCartIcon"];

            //Return a tag of this item 
            return (value as ComboBoxItem).Tag;

          
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
