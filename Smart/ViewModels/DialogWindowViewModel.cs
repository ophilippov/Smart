

using Smart.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Smart
{
    /// <summary>
    /// The view model for the custom dialog window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties


        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public DialogWindowViewModel(Window window):base(window)
        {
            //Make minimum size smaller
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;
           
            
        }
        #endregion

       
    }
}
