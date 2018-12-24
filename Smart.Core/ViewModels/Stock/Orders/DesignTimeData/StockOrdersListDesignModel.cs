using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="OrdersListControl"> can display
    /// </summary>
    public class StockOrdersListDesignModel:StockOrdersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static StockOrdersListDesignModel Instance => new StockOrdersListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public StockOrdersListDesignModel()
        {
            Orders = new List<StockOrdersListItemViewModel>
            {
                new StockOrdersListItemViewModel
                {
                    Name = "Филиппов Олег Анатольевич",
                    OrderStatus = OrderStatus.StockApproved,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123456",
                    Price = 612.80d,
                },

                new StockOrdersListItemViewModel
                {
                    Name = "Кулмамадов Владислав Давлатмуродович",
                    OrderStatus = OrderStatus.StockProcessing,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123466",
                    Price = 25d
                },

                 new StockOrdersListItemViewModel
                {
                    Name = "Черба Елена Анатольевна",
                    OrderStatus = OrderStatus.StockRejected,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123456",
                    Price = 20d
                },

                   new StockOrdersListItemViewModel
                {
                    Name = "Гайдаржи Николай Николаевич",
                    OrderStatus = OrderStatus.TransferedToSC,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "123456",
                    Price = 520.15d
                },

                  new StockOrdersListItemViewModel
                {
                    Name = "Белов Игорь Игоревич",
                    OrderStatus = OrderStatus.StockDepartured,
                    OrderDate = DateTime.UtcNow.Date,
                    OrderNumber = "121256",
                    Price = 58.2d
                }

              
                  
            };
        }
        #endregion



    }
}
