using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="OrdersListItemControl"> can display
    /// </summary>
    public class OrdersListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected order item
        /// </summary>
        private static OrdersListItemViewModel mCurrentlySelectedOrderItem = null;

        /// <summary>
        /// Invoice number bor this order
        /// </summary>
        private string mInvoiceNumber = String.Empty;
        #endregion

        #region Public properties



        /// <summary>
        /// The name of current customer
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The status of this order
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// The status of payment of this order
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// The number of this order
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// The invoice number of this order
        /// </summary>
        public string InvoiceNumber
        {
            get => String.IsNullOrEmpty(mInvoiceNumber) ? @"<не создана>" : mInvoiceNumber;
            set => mInvoiceNumber = value;
        }

        /// <summary>
        /// The date this order was created
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Amount of money to be paid
        /// </summary>
        public double PaymentAmount { get; set; }

        /// <summary>
        /// This order's price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Indicates if this order item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;


        /// <summary>
        /// Indicates if more region is open now
        /// </summary>
        public bool IsMoreOpen { get; private set; } = false;


        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this order item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open more region
        /// </summary>
        public ICommand OpenMoreCommand { get; set; }

        /// <summary>
        /// A command to open current order
        /// </summary>
        public ICommand OpenOrderCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public OrdersListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenOrderCommand = new RelayCommand(OpenOrder);
            OpenMoreCommand = new RelayCommand(OpenMore);

            //Hook into the CurrentOrderNumberNullChanged event
            IoC.Manager.CurrentOrderNumberNullChanged += Unselect;
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected order
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent order item 
            if (mCurrentlySelectedOrderItem != null)
                mCurrentlySelectedOrderItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedOrderItem = null;

            //If more region is currently open, close it
            if (IsMoreOpen)
                IsMoreOpen = false;

        }
        #endregion


        #region Command Methods

        /// <summary>
        /// Selects current order item
        /// </summary>
        private void Select()
        {

            //If this item is currently selected, do nothing
            if (mCurrentlySelectedOrderItem == this)
                return;


            //Try to get int value from the OrderNumber string
            if (Int32.TryParse(OrderNumber, out int orderNumber))
            {
               
                //Unselect previous order item
                if (mCurrentlySelectedOrderItem != null)
                {
                    //If more region is currently open in the previous selected item, close it
                    if (mCurrentlySelectedOrderItem.IsMoreOpen)
                        mCurrentlySelectedOrderItem.IsMoreOpen = false;

                    //Unselect previous order item
                    mCurrentlySelectedOrderItem.IsSelected = false;
                }
                    
                

                //Sets a single instance of CurrentOrderNumber to this order's number
                IoC.Manager.CurrentOrderNumber = orderNumber;
                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedOrderItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this order number");

        }

        /// <summary>
        /// Opens curent order item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenOrder()
        {
            //Select this order
            Select();

            //Ask shared view model to open currently selected product
            IoC.Manager.InfoOrderCommand.Execute(null);

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
