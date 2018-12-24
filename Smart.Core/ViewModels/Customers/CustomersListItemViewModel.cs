using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="CustomersListItemControl"> can display
    /// </summary>
    public class CustomersListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected customer item
        /// </summary>
        private static CustomersListItemViewModel mCurrentlySelectedCustomerItem = null;
        #endregion

        #region Public properties

        /// <summary>
        /// A number (or ID) of this customer
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// A name of this customer
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// A name of the director
        /// </summary>
        public string DirectorName { get; set; }

        /// <summary>
        /// A juridical status of this customer
        /// </summary>
        public JuridicalStatus JuridicalStatus { get; set; }

        /// <summary>
        /// A status of this customer
        /// </summary>
        public CustomerStatus CustomerStatus { get; set; }

        /// <summary>
        /// A debt of this customer
        /// </summary>
        public double DebtsSumm { get; set; }

        /// <summary>
        /// A rating of this customer
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// A namber of active orders of this customer
        /// </summary>
        public int ActiveOrders { get; set; }

        /// <summary>
        /// Indicates if this customer item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;


        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this customer item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open current customer
        /// </summary>
        public ICommand OpenCustomerCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomersListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenCustomerCommand = new RelayCommand(OpenCustomer);

            //Hook into the CurrentCustomerNumberNullChanged event
            IoC.Customers.CurrentCustomerNumberNullChanged += Unselect;
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected customer
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent customer item 
            if (mCurrentlySelectedCustomerItem != null)
                mCurrentlySelectedCustomerItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedCustomerItem = null;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// Selects current customer item
        /// </summary>
        private void Select()
        {
            //Try to get int value from the CustomerNumber string
            if (Int32.TryParse(CustomerNumber, out int customerNumber))
            {
                //Unselect previous customer item
                if (mCurrentlySelectedCustomerItem != null)
                    mCurrentlySelectedCustomerItem.IsSelected = false;

                //Sets a single instance of CurrentCustomerNumber to this customer's number


                IoC.Customers.CurrentCustomerNumber = customerNumber;

                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedCustomerItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this customer number");

        }

        /// <summary>
        /// Opens curent customer item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenCustomer()
        {
            //Select this customer
            Select();

            //Ask shared view model to open currently selected customer
            IoC.Customers.InfoCustomerCommand.Execute(null);

        }


        #endregion
    }
}
