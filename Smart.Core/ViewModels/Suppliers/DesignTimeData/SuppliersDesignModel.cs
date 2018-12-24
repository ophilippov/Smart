using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{ 

    /// <summary>
    /// The class that provides design data for Suppliers menu tab
    /// </summary>
    public class SuppliersDesignModel:AppSuppliersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static SuppliersDesignModel Instance => new SuppliersDesignModel();
        #endregion


        #region Public Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public SuppliersDesignModel()
        {
            
        }
        #endregion



    }
}
