using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="OrdersListItemControl"> can display
    /// </summary>
    public class OrdersListItemDesignModel:OrdersListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static OrdersListItemDesignModel Instance => new OrdersListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public OrdersListItemDesignModel()
        {
            Name = "Филиппов Олег Анатольевич";
            OrderStatus = OrderStatus.NewOrder;
            PaymentStatus = PaymentStatus.Overdue;
            OrderDate = DateTime.UtcNow.Date;
            OrderNumber = "123456";
            PaymentAmount = 612.6d;
            Price = 1205.40d;
        }
        #endregion



    }
}
