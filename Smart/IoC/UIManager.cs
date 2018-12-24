using System;
using System.Threading.Tasks;
using Smart.Core;
using System.Windows;

namespace Smart
{
    /// <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {

        /// <summary>
        /// Displays a single box message to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
