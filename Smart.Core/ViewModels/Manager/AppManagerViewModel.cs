using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// ViewModel for the Orders item of the TabMenu
    /// </summary>
    public class AppManagerViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Number of the currently selected order
        /// </summary>
        private int? mCurrentOrderNumber = null;
        #endregion

        #region Public commands

        /// <summary>
        /// A command for creating new order
        /// </summary>
        public ICommand NewOrderCommand { get; set; }

        /// <summary>
        /// A command for editing current order
        /// </summary>
        public ICommand EditOrderCommand { get; set; }

        /// <summary>
        /// A command for printing current order
        /// </summary>
        public ICommand PrintOrderCommand { get; set; }

        /// <summary>
        /// A command for deleting current order
        /// </summary>
        public ICommand DeleteOrderCommand { get; set; }

        /// <summary>
        /// A command for opening new dialog window with information about customer
        /// </summary>
        public ICommand CustomerInfoOrderCommand { get; set; }

        /// <summary>
        /// A command to open dialog with payment details
        /// </summary>
        public ICommand PaymentOrderCommand { get; set; }

        /// <summary>
        /// A command for opening new dialog window with information about this order
        /// </summary>
        public ICommand InfoOrderCommand { get; set; }

        /// <summary>
        /// A command to open invoice for this order
        /// </summary>
        public ICommand InvoiceOrderCommand { get; set; }

        /// <summary>
        /// A command to set a sort order
        /// </summary>
        public ICommand SortOrderCommand { get; set; }

        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires when current order changes to null
        /// </summary>
        public event Action CurrentOrderNumberNullChanged;
        #endregion

        #region Public Properties

        /// <summary>
        /// Number of currently selected order
        /// </summary>
        public int? CurrentOrderNumber
        {
            get => mCurrentOrderNumber;
            set
            {
                mCurrentOrderNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentOrderNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// Number of all orders
        /// </summary>
        public int AllOrdersCount { get; set; }

        /// <summary>
        /// Number of active orders (new+processing+delivering)
        /// </summary>
        public int ActiveOrdersCount { get; set; }


        /// <summary>
        /// Number of new orders
        /// </summary>
        public int NewOrdersCount { get; set; }

        /// <summary>
        /// Number of rejected orders
        /// </summary>
        public int RejectedOrdersCount { get; set; }

        /// <summary>
        /// Number of overdue orders
        /// </summary>
        public int OverdueOrdersCount { get; set; }

        /// <summary>
        /// Number of closed orders
        /// </summary>
        public int ClosedOrdersCount { get; set; }

        /// <summary>
        /// Number of orders in processing
        /// </summary>
        public int ProcessingOrdersCount { get; set; }

        /// <summary>
        /// Number of orders that wait for payment
        /// </summary>
        public int PaymentWaitingOrdersCount { get; set; }

        /// <summary>
        /// Number of cancelled orders
        /// </summary>
        public int CancelledOrdersCount { get; set; }

        /// <summary>
        /// Number of orders that is delivering, transfered to SC, or delivered
        /// </summary>
        public int DeliveringOrdersCount { get; set; }

        /// <summary>
        /// Sorting order for orders
        /// </summary>
        public OrderSortBy SortingOrder { get; set; } = OrderSortBy.OrderCreationDate;

        /// <summary>
        /// Orders to be shown
        /// </summary>
        public OrderShow ShowingOrders { get; set; } = OrderShow.AllOrders;

        /// <summary>
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingType { get; set; } = false;




        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppManagerViewModel()
        {
            //Initialize all commands

            NewOrderCommand = new RelayCommand(NewOrder);
            EditOrderCommand = new RelayCommand(EditOrder);
            PrintOrderCommand = new RelayCommand(PrintOrder);
            DeleteOrderCommand = new RelayCommand(DeleteOrder);
            CustomerInfoOrderCommand = new RelayCommand(CustomerInfoOrder);
            PaymentOrderCommand = new RelayCommand(PaymentOrder);
            InfoOrderCommand = new RelayCommand(InfoOrder);
            InvoiceOrderCommand = new RelayCommand(InvoiceOrder);
            SortOrderCommand = new RelayCommand(SortOrder);

            //Get summary about orders
            GetSummary();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets summary about orders
        /// </summary>
        private void GetSummary()
        {
            //TODO: gets summary about orders
        }

        #endregion

        #region Commands Handlers
        

        /// <summary>
        /// Create new order
        /// </summary>
        private void NewOrder() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit currently selected order
        /// </summary>
        private void EditOrder()
        {
           throw new NotImplementedException();
        }

        /// <summary>
        /// Print currently selected order
        /// </summary>
        private void PrintOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete currently selected order
        /// </summary>
        private void DeleteOrder()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show info about customer
        /// </summary>
        private void CustomerInfoOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Show payment info about currently selected order
        /// </summary>
        private void PaymentOrder()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show all info about currently selected order
        /// </summary>
        private void InfoOrder()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущий заказ",
                Message = $"Текущий выбранный заказ: {CurrentOrderNumber}"

            };
            IoC.UI.ShowMessage(vm);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Show invoice for currently selected order
        /// </summary>
        private void InvoiceOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set sorting order 
        /// </summary>
        private void SortOrder()
        {
            //Inverts a current value of SortingType
            SortingType ^= true;
        }
        #endregion

    }

}
