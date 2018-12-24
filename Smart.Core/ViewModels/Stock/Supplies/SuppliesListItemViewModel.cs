using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="SuppliesListItemControl"> can display
    /// </summary>
    public class SuppliesListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected supply item
        /// </summary>
        private static SuppliesListItemViewModel mCurrentlySelectedSupplyItem = null;

        /// <summary>
        /// Invoice number for this supply
        /// </summary>
        private string mInvoiceNumber = String.Empty;
        #endregion

        #region Public properties



        /// <summary>
        /// The name of this company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The status of this Supply
        /// </summary>
        public SupplyStatus SupplyStatus { get; set; }

        /// <summary>
        /// The status of payment of this Supply
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// The number of this Supply
        /// </summary>
        public string SupplyNumber { get; set; }

        /// <summary>
        /// The invoice number of this order
        /// </summary>
        public string InvoiceNumber
        {
            get => String.IsNullOrEmpty(mInvoiceNumber) ? @"<не создана>" : mInvoiceNumber;
            set => mInvoiceNumber = value;
        }


        /// <summary>
        /// The date this Supply was created
        /// </summary>
        public DateTime SupplyCreationDate { get; set; }

        /// <summary>
        /// Amount of money to be paid
        /// </summary>
        public double PaymentAmount { get; set; }

        /// <summary>
        /// Price of this supply
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Indicates if this Supply item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;

        /// <summary>
        /// Indicates if more region is open now
        /// </summary>
        public bool IsMoreOpen { get; private set; } = false;

        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this Supply item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open current Supply
        /// </summary>
        public ICommand OpenSupplyCommand { get; set; }


        /// <summary>
        /// A command to open more region
        /// </summary>
        public ICommand OpenMoreCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SuppliesListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenSupplyCommand = new RelayCommand(OpenSupply);

            OpenMoreCommand = new RelayCommand(OpenMore);

            //Hook into the CurrentSupplyNumberNullChanged event
            IoC.Stock.CurrentSupplyNumberNullChanged += Unselect;
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected supply
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent supply item 
            if (mCurrentlySelectedSupplyItem != null)
                mCurrentlySelectedSupplyItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedSupplyItem = null;

            //If more region is currently open, close it
            if (IsMoreOpen)
                IsMoreOpen = false;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// Selects current supply item
        /// </summary>
        private void Select()
        {
            //If this item is currently selected, do nothing
            if (mCurrentlySelectedSupplyItem == this)
                return;

            //Try to get int value from the SupplyNumber string
            if (Int32.TryParse(SupplyNumber, out int supplyNumber))
            {
                //Unselect previous supply item
                if (mCurrentlySelectedSupplyItem != null)
                {
                    //If more region is currently open in the previous selected item, close it
                    if (mCurrentlySelectedSupplyItem.IsMoreOpen)
                        mCurrentlySelectedSupplyItem.IsMoreOpen = false;

                    //Unselect previous supply item
                    mCurrentlySelectedSupplyItem.IsSelected = false;
                }
                //Sets a single instance of CurrentSupplyNumber to this supply's number
                IoC.Stock.CurrentSupplyNumber = supplyNumber;
                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedSupplyItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this supply number");

        }

        /// <summary>
        /// Opens curent Supply item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenSupply()
        {
            //Select this order
            Select();

            //Ask shared view model to open currently selected supply
            IoC.Stock.InfoSupplyCommand.Execute(null);

        }

        /// <summary>
        /// Opens more region or close it
        /// </summary>
        private void OpenMore()
        {
            //Select this item
            Select();

            //Inverts current value
            IsMoreOpen = !IsMoreOpen;

        }
        #endregion
    }
}
