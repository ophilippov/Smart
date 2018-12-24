

namespace Smart.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageBoxDialogDesignModel()
        {

            Message = "An unexpected exception has occured. Do you want to report this bug to developers? ";
            Type = DialogType.Warning;
            Button = DialogButton.YesNoMore;
            DefaultButton = DialogDefaultButton.Yes;
            ButtonText = new DialogButtonText(moreText: "Help", yesText: "Report", noText: "Ignore");
        }

        #endregion
    }
}
