using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data for Stock menu tab
    /// </summary>
    public class StockDesignModel:AppStockViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static StockDesignModel Instance => new StockDesignModel();
        #endregion


        #region Public Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public StockDesignModel()
        {
            CurrentCategory = StockCategory.WriteOffs;
        }
        #endregion



    }
}
