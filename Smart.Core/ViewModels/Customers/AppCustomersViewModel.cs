using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// ViewModel for the Customers item of the TabMenu
    /// </summary>
    public class AppCustomersViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Number of the currently selected customer
        /// </summary>
        private int? mCurrentCustomerNumber = null;
        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires when current customer changes to null
        /// </summary>
        public event Action CurrentCustomerNumberNullChanged;
        #endregion

        #region Public commands

        /// <summary>
        /// The command to create a new customer
        /// </summary>
        public ICommand NewCustomerCommand { get; set; }

        /// <summary>
        /// The command to edit currently selected customer
        /// </summary>
        public ICommand EditCustomerCommand { get; set; }
        
        /// <summary>
        /// The command to delete currently selected customer
        /// </summary>
        public ICommand DeleteCustomerCommand { get; set; }

        /// <summary>
        /// The command to get info about currently selected customer
        /// </summary>
        public ICommand InfoCustomerCommand { get; set; }

        /// <summary>
        /// The command to print info about currently selected customer
        /// </summary>
        public ICommand PrintCustomerCommand { get; set; }

        /// <summary>
        /// The command to get info about orders of the currently selected customer
        /// </summary>
        public ICommand InfoOrdersCustomerCommand { get; set; }

        /// <summary>
        /// The command to get info about discounts of the currently selected customer
        /// </summary>
        public ICommand InfoDiscountsCustomerCommand { get; set; }

        /// <summary>
        /// The command to get info about payments of the currently selected customer
        /// </summary>
        public ICommand InfoPaymentsCustomerCommand { get; set; }


        /// <summary>
        /// A command to set a sorting order
        /// </summary>
        public ICommand SortCustomersCommand { get; set; }
        #endregion

        #region Public Properties

        /// <summary>
        /// Number of all customers
        /// </summary>
        public int AllCustomersCount { get; set; }

        /// <summary>
        /// Number of all artificial customers
        /// </summary>
        public int ArtificialCustomersCount { get; set; }

        /// <summary>
        /// Number of all individual customers
        /// </summary>
        public int IndividualCustomersCount { get; set; }

        /// <summary>
        /// Number of active customers
        /// </summary>
        public int ActiveCustomersCount { get; set; }

        /// <summary>
        /// Number of inactive customers
        /// </summary>
        public int InactiveCustomersCount { get; set; }

        /// <summary>
        /// Number of customers with positive raiting
        /// </summary>
        public int PositiveRatingCustomersCount { get; set; }

        /// <summary>
        /// Number of customers with negative raiting
        /// </summary>
        public int NegativeRatingCustomersCount { get; set; }

        /// <summary>
        /// Number of customers with debts
        /// </summary>
        public int DebtorsCustomersCount { get; set; }


        /// <summary>
        /// Number of the currently selected customer
        /// </summary>
        public int? CurrentCustomerNumber {
            get => mCurrentCustomerNumber;
            set
            {
                mCurrentCustomerNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentCustomerNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// A sorting order for customers
        /// </summary>
        public CustomerSortBy CustomerSortBy { get; set; } = CustomerSortBy.CustomerName;

        /// <summary>
        /// Sets wich customers must be shown
        /// </summary>
        public CustomerShow CustomerShow { get; set; } = CustomerShow.AllCustomers;

        /// <summary>
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingType { get; set; } = false;

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppCustomersViewModel()
        {
            //Initialize all commands for discounts

            NewCustomerCommand = new RelayCommand(NewCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            PrintCustomerCommand = new RelayCommand(PrintCustomer);
            InfoDiscountsCustomerCommand = new RelayCommand(InfoDiscountsCustomer);
            InfoOrdersCustomerCommand = new RelayCommand(InfoOrdersCustomer);
            InfoCustomerCommand = new RelayCommand(InfoCustomer);
            SortCustomersCommand = new RelayCommand(SortCustomer);
            InfoPaymentsCustomerCommand = new RelayCommand(InfoPaymentsCustomer);
           
            //Get summary about discounts
            GetSummary();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets summary about customers
        /// </summary>
        private void GetSummary()
        {
            //TODO: gets summary about customers
        }

        #endregion

        #region Commands helpers

        /// <summary>
        /// Creates a new customer
        /// </summary>
        private void NewCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits info about the currently selected customer
        /// </summary>
        private void EditCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the currently selected customer
        /// </summary>
        private void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the currently selected customer
        /// </summary>
        private void InfoCustomer()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущий клиент",
                Message = $"Текущий выбранный клиент: {CurrentCustomerNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }
    

        /// <summary>
        /// Shows info about the currently selected customer's payments
        /// </summary>
        private void InfoPaymentsCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the currently selected customer's discounts
        /// </summary>
        private void InfoDiscountsCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the currently selected customer's orders
        /// </summary>
        private void InfoOrdersCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints info about the currently selected customer
        /// </summary>
        private void PrintCustomer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a sorting order 
        /// </summary>
        private void SortCustomer()
        {
            //Inverts a current value of SortingType
            SortingType ^= true;
        }
        #endregion

    }

}
