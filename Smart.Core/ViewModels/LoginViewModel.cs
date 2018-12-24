

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// The view model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The Username of the user
        /// </summary>
        public string Username { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register new user
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }




        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public LoginViewModel()
        {

            // Create commands 
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));

            // Create commands 
            RegisterCommand = new RelayCommand(async () => await Register());

        }






        #endregion

        #region Helper Functions

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The SecureString passed in from the view for the users password</param>
        /// <returns></returns>
        private async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
              {
                  await Task.Delay(300);
                  IoC.Application.IsLoggedIn = true;
                  //Make menu visible
                  IoC.Application.TabMenuVisibility = true;

                  //Configure app to work as a manager
                  AppConfigure.OrdersConfigure();

                  



                  //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                  //var uname = this.Username;
            });

        }

        /// <summary>
        /// Takes the user to the register page 
        /// </summary>
        /// <returns></returns>
        private async Task Register()
        {
            IoC.Application.GoToPageMain(ApplicationPage.Register);
            //IoC.Get<ApplicationViewModel>().TabMenuVisibility ^= true;
            //TODO: Go to the register page
            //IoC.Get<ApplicationViewModel>().CurrentMainPage = ApplicationMainPage.ManagerOrders;
            await Task.Delay(1);
        }

        #endregion


    }
}
