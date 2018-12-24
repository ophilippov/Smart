
using Smart.Core;
using System;
using System.Windows;
using System.Windows.Input;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для DialogMessageBox.xaml
    /// </summary>
    public partial class DialogMessageBox : BaseDialogUserControl
    {
        #region Public Commands

        /// <summary>
        /// A command for the OK button
        /// </summary>
        public ICommand OKCommand { get; set; }


        /// <summary>
        /// A command for the Cancel button
        /// </summary>
        public ICommand CancelCommand { get; set; }


        /// <summary>
        /// A command for the Yes button
        /// </summary>
        public ICommand YesCommand { get; set; }


        /// <summary>
        /// A command for the No button
        /// </summary>
        public ICommand NoCommand { get; set; }


        /// <summary>
        /// A command for the More button
        /// </summary>
        public ICommand MoreCommand { get; set; }



        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogMessageBox()
        {
            InitializeComponent();

            InitializeCommands();
        }

        #endregion


        #region Private Helpers

        /// <summary>
        /// Initialize all commands
        /// </summary>
        private void InitializeCommands()
        {
            OKCommand = new RelayCommand(() => OKCommandAction());
            CancelCommand = new RelayCommand(() => CancelCommandAction());
            YesCommand = new RelayCommand(() => YesCommandAction());
            NoCommand = new RelayCommand(() => NoCommandAction());
            MoreCommand = new RelayCommand(() => MoreCommandAction());
        }

        private void MoreCommandAction()
        {
            //Set the dialog result
            (this.DataContext as MessageBoxDialogViewModel).Result = DialogResult.More;
            //Close this dialog
            CloseCommand.Execute(null);
        }

        private void NoCommandAction()
        {
            //Set the dialog result

            (this.DataContext as MessageBoxDialogViewModel).Result = DialogResult.No;
            //Close this dialog
            CloseCommand.Execute(null);
        }

        private void YesCommandAction()
        {
            //Set the dialog result

            (this.DataContext as MessageBoxDialogViewModel).Result = DialogResult.Yes;
            //Close this dialog
            CloseCommand.Execute(null);
        }

        private void CancelCommandAction()
        {
            //Set the dialog result

            (this.DataContext as MessageBoxDialogViewModel).Result = DialogResult.Cancel;
            //Close this dialog
            CloseCommand.Execute(null);
        }

        private void OKCommandAction()
        {
            //Set the dialog result

            (this.DataContext as MessageBoxDialogViewModel).Result = DialogResult.Ok;
            //Close this dialog
            CloseCommand.Execute(null);
        }


        #endregion
    }
}
