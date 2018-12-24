using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data for Discounts menu tab
    /// </summary>
    public class DiscountsDesignModel:AppDiscountsViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static DiscountsDesignModel Instance => new DiscountsDesignModel();
        #endregion


        #region Public Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public DiscountsDesignModel()
        {
            
        }
        #endregion



    }
}
