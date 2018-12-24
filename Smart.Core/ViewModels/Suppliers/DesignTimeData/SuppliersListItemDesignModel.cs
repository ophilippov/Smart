using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="SuppliersListItemControl"> can display
    /// </summary>
    public class SuppliersListItemDesignModel:SuppliersListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static SuppliersListItemDesignModel Instance => new SuppliersListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public SuppliersListItemDesignModel()
        {
            SupplierNumber = "1512152";
            SupplierName = @"ПрАО ""WD-40 Ukraine Distribution""";
            DirectorName = "Сазонов Г.А.";
            JuridicalStatus = JuridicalStatus.Artificial;
            DebtsSumm = 125.80d;
            ActiveSupplies = 5;
            SupplierStatus = SupplierStatus.Active;
        }
        #endregion



    }
}
