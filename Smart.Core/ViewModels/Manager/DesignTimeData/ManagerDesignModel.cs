using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="OrdersListControl"> can display
    /// </summary>
    public class ManagerDesignModel:AppManagerViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static ManagerDesignModel Instance => new ManagerDesignModel();
        #endregion


        #region Public Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public ManagerDesignModel()
        {
            ShowingOrders = OrderShow.ActiveOrders;
            SortingOrder = OrderSortBy.OrderPrice;
            AllOrdersCount = 1520;
            ActiveOrdersCount = 256;
            NewOrdersCount = 5;
            RejectedOrdersCount = 3;
            OverdueOrdersCount = 10;
            ClosedOrdersCount = 1264;
            ProcessingOrdersCount = 59;
            PaymentWaitingOrdersCount = 10;
            CancelledOrdersCount = 6;
            DeliveringOrdersCount = 23;
            SortingType = false;
        }
        #endregion



    }
}
