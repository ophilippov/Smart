using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Customers page
    /// </summary>
    public class CustomersViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// A command to unselect any customer
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public CustomersViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The customers list items for the list
        /// </summary>
        public List<CustomersListItemViewModel> Customers { get; set; } = null;

        /// <summary>
        /// Indicates if the Customers list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Customers == null || Customers.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        /// <summary>
        /// Unseletcs currently selected customer
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected customer item
            IoC.Customers.CurrentCustomerNumber = null; 
            
        }
        #endregion

    }
}
