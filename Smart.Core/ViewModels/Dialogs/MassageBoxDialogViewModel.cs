

namespace Smart.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        
        /// <summary>
        /// The message to display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The icon to display
        /// </summary>
        public DialogType Type { get; set; } = DialogType.Information;

        /// <summary>
        /// Buttons to display
        /// </summary>
        public DialogButton Button { get; set; } = DialogButton.Ok;

        /// <summary>
        /// Text for buttons
        /// </summary>
        public DialogButtonText ButtonText { get; set; } = new DialogButtonText();

        /// <summary>
        /// A button to be default
        /// </summary>
        public DialogDefaultButton DefaultButton { get; set; } = DialogDefaultButton.Ok;


        /// <summary>
        /// A result of the dialog
        /// </summary>
        public DialogResult Result { get; set; }

    }

    /// <summary>
    /// Texts for a message box buttons. Change if you want to customize this dialog
    /// </summary>
    public class DialogButtonText
    {
        public string OKText;

        public string CancelText;

        public string YesText;

        public string NoText;

        public string MoreText;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="okText">OK button</param>
        /// <param name="cancelText">Cancel button</param>
        /// <param name="yesText">Yes button</param>
        /// <param name="noText">No button</param>
        /// <param name="moreText">More button</param>
        public DialogButtonText(string okText = "OK",
                                string cancelText = "Cancel", 
                                string yesText = "Yes",
                                string noText = "No", 
                                string moreText = "More")
        {
            OKText = okText;
            CancelText = cancelText;
            YesText = yesText;
            NoText = noText;
            MoreText = moreText;
        }
        #endregion
    }
}
