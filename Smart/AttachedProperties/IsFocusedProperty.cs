
using System.Windows;
using System.Windows.Controls;

namespace Smart
{

    /// <summary>
    /// The IsFocused attached property for an anything that wants to flag if the control is busy
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //If we don`t have a control, return
            if (!(sender is Control control))
                return;

            //Focus this control once loaded
            control.Loaded += (ss, ee) => control.Focus();

        }
    }
}

