

using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// The view model for a ManagerSearch screen
    /// </summary>
    public class OrdersSearchViewModel : BaseViewModel
    {

        #region Public Properties

        
        #endregion

        #region Commands

        /// <summary>
        /// The command to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        
        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool SearchIsRunning { get; set; }




        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public OrdersSearchViewModel()
        {

            // Create commands 
            SearchCommand = new RelayParameterizedCommand(async (parameter) => await Search(parameter));


        }

       




        #endregion

        #region Helper Functions

        /// <summary>
        /// Attempts to find required info (e.g. Order)
        /// </summary>
        /// <param name="parameter">The array of parameters passed in from the view </param>
        /// <returns></returns>
        private async Task Search(object parameter)
        {
           
           
            await RunCommand(() => this.SearchIsRunning, async () =>
              {
                  IoC.Application.TabMenuVisibility = false;

                  var vm = new MessageBoxDialogViewModel
                  {
                      Title="Unexpected error",
                      Message = "An unexpected exception has occured. Do you want to report this bug to developers? ",
                      Type = DialogType.Warning,
                      Button = DialogButton.YesNoMore,
                      DefaultButton = DialogDefaultButton.Yes,
                      ButtonText = new DialogButtonText(moreText: "Help", yesText: "Report", noText: "Ignore")
                  };

                  await IoC.UI.ShowMessage(vm);
                  

                  DialogResult result = vm.Result;

                  await Task.Delay(305);

                  if (result == DialogResult.Yes)
                  {
                      vm = new MessageBoxDialogViewModel
                      {
                          Title = "Success",
                          Message = "Bug report has been submited",
                          Type = DialogType.Success,
                          Button = DialogButton.Ok,
                          DefaultButton = DialogDefaultButton.Ok
                      };
                      await IoC.UI.ShowMessage(vm);
                  }
                 
                  result = vm.Result;
                  IoC.Application.TabMenuVisibility = true;





                  await Task.Delay(1000);

                  //IoC.Get<ApplicationViewModel>().GoToPageMain(ApplicationMainPage.ManagerOrders);
                  //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                  //var uname = this.Username;
              });
            
        }

       
        #endregion


    }
}
