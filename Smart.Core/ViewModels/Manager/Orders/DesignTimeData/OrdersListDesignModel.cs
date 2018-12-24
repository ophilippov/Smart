using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="OrdersListControl"> can display
    /// </summary>
    public class OrdersListDesignModel:OrdersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static OrdersListDesignModel Instance => new OrdersListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public OrdersListDesignModel()
        {
            Orders = new List<OrdersListItemViewModel>
            {
                new OrdersListItemViewModel
                {
                    Name = "Филиппов Олег Анатольевич",
                    OrderStatus = OrderStatus.Closed,
                    PaymentStatus = PaymentStatus.Overdue,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123456",
                    PaymentAmount = 612.80d,
                    Price = 820.10d
                },

                new OrdersListItemViewModel
                {
                    Name = "Кулмамадов Владислав Давлатмуродович",
                    OrderStatus = OrderStatus.ManagerProcessing,
                    PaymentStatus = PaymentStatus.Paid,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123466",
                    PaymentAmount = 0.00d,
                    Price = 25.50d
                },

                 new OrdersListItemViewModel
                {
                    Name = "Черба Елена Анатольевна",
                    OrderStatus = OrderStatus.StockProcessing,
                    PaymentStatus = PaymentStatus.PaidForPart,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123456",
                    PaymentAmount = 20.00d,
                    Price = 1362.46d
                },

                  new OrdersListItemViewModel
                {
                    Name = "Белов Игорь Игоревич",
                    OrderStatus = OrderStatus.Cancelled,
                    PaymentStatus = PaymentStatus.ReturningMoney,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "121256",
                    PaymentAmount = 0.00d,
                    Price = 156.90d
                },

               
                  
            };
        }
        #endregion



    }
}
