using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="SuppliesListItemControl"> can display
    /// </summary>
    public class SuppliesListItemDesignModel: SuppliesListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static SuppliesListItemDesignModel Instance => new SuppliesListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public SuppliesListItemDesignModel()
        {
            CompanyName = @"OOO ""ОдессаЮгСтрой""";
            PaymentAmount = 252.5d;
            PaymentStatus = PaymentStatus.Overdue;
            SupplyStatus = SupplyStatus.Done;
            Price = 1256.80d;
            SupplyNumber = "01233511";
            SupplyCreationDate = DateTime.UtcNow.Date;

        }
        #endregion



    }
}
