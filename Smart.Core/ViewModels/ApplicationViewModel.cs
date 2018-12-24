using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel:BaseViewModel
    {

        /// <summary>
        /// The current main page of the application
        /// </summary>
        public ApplicationPage CurrentMainPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentMainPage changes
        /// NOTE: This is not live up-to-date view model. It is simply used
        ///       to set the view model of the current page at the time it changes
        /// </summary>
        public BaseViewModel CurrentMainPageViewModel { get; private set; }

        /// <summary>
        /// The current additional page of the application
        /// </summary>
        public ApplicationPage CurrentAdditionalPage { get; private set; } = ApplicationPage.None;

        /// <summary>
        /// If true, main Tab menu is visible
        /// </summary>
        public bool TabMenuVisibility { get; set; } = false;

        /// <summary>
        /// Sets to true, if user is already logged in
        /// </summary>
        public bool IsLoggedIn { get; set; } = false;

        /// <summary>
        /// Sets the current main page of the application
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="viewModel">A specific view model, if any, to set explicitly to the new page </param>
        public void GoToPageMain(ApplicationPage mainPage, BaseViewModel viewModel = null)
        {
            //Set the view model
            CurrentMainPageViewModel = viewModel;

            if (CurrentMainPage != mainPage)
            {
                //Set the current main page
                CurrentMainPage = mainPage;

                //We don't need to fire OnPropertyChanged if the page has changed
                return;
            }

            //Set the current main page
            CurrentMainPage = mainPage;

            //Fire off a CurrentMainPage changed event
            OnPropertyChanged(nameof(CurrentMainPage));
        }

        /// <summary>
        /// Sets the current additional page of the application
        /// </summary>
        /// <param name="additionalPage"></param>
        public void GoToPageAdditional(ApplicationPage additionalPage)
        {
            //Set the current additional page
            CurrentAdditionalPage = additionalPage;
        }
    }
}
