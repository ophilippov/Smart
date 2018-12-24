

using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The UI manager that handles any UI interaction in the appliation
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single box message to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);

    }
}
