

using Smart.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace Smart
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl:UserControl
    {
        #region Private Members

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;


        /// <summary>
        /// The title for this dialog
        /// </summary>
        public string Title { get; set; }
        
        #endregion

        #region Public Commands

        /// <summary>
        /// The command to close this dialog
        /// </summary>
        public ICommand CloseCommand { get; set; }

       
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            //Create a new dialog window
            mDialogWindow = new DialogWindow();

            //Set a view model for this window
            mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

            //Create new commands
            CloseCommand = new RelayCommand(() => mDialogWindow.Close());

            
        }
        #endregion

        #region Public Dialog Shows Methods


        /// <summary>
        /// Displays a single box message to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T"> The view model type for this control </typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T:BaseDialogViewModel
        {

            //Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            //Run on UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //Match controls to the expected sizes to the dialog windows view model
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;

                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    //Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    //Show in the center of the parent
                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    //Show the dialog
                    mDialogWindow.ShowDialog(); 
                }
                finally
                {
                    
                    //Let caller now we are finished
                    tcs.TrySetResult(true);
                }
            });

            
            return tcs.Task;
        }
        #endregion

       
    }

}
