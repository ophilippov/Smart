

using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// The view model for a login screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The Username of the user
        /// </summary>
        public string Username { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// The command to go to the login page
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register new user
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }




        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public RegisterViewModel()
        {

            // Create commands 
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));

            // Create commands 
            LoginCommand = new RelayCommand(async () => await Login());

        }

       




        #endregion

        #region Helper Functions

        /// <summary>
        /// Attempts to register new user
        /// </summary>
        /// <param name="parameter">The SecureString passed in from the view for the users password</param>
        /// <returns></returns>
        private async Task Register(object parameter)
        {
            await RunCommand(() => this.RegisterIsRunning, async () =>
              {
                  await Task.Delay(5000);
                 
              });
            
        }

        /// <summary>
        /// Takes the user to the login page 
        /// </summary>
        /// <returns></returns>
        private async Task Login()
        {
            IoC.Application.GoToPageMain(ApplicationPage.Login);
            //IoC.Get<ApplicationViewModel>().TabMenuVisibility ^= true;
            //TODO: Go to the register page
            //IoC.Get<ApplicationViewModel>().CurrentMainPage = ApplicationMainPage.ManagerOrders;
            await Task.Delay(1);
        }

        #endregion


    }
}
