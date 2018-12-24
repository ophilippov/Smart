using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{ 

    /// <summary>
    /// The class that provides design data for Customers menu tab
    /// </summary>
    public class CustomersDesignModel:AppCustomersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static CustomersDesignModel Instance => new CustomersDesignModel();
        #endregion


        #region Public Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public CustomersDesignModel()
        {
            
        }
        #endregion



    }
}
