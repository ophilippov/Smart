using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="StockOrdersListItemControl"> can display
    /// </summary>
    public class StockOrdersListItemDesignModel:StockOrdersListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static StockOrdersListItemDesignModel Instance => new StockOrdersListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public StockOrdersListItemDesignModel()
        {
            Name = "Филиппов Олег Анатольевич";
            OrderStatus = OrderStatus.StockProcessing;
            OrderDate = DateTime.UtcNow.Date;
            OrderNumber = "123456";
            Price = 612.80d;
        }
        #endregion



    }
}
