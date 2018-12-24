using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="CustomersListItemControl"> can display
    /// </summary>
    public class CustomersListItemDesignModel:CustomersListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static CustomersListItemDesignModel Instance => new CustomersListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public CustomersListItemDesignModel()
        {
            CustomerNumber = "1512152";
            CustomerName = @"ПрАО ""ОдессаСтальКанат""";
            DirectorName = "Дегтярев А.И.";
            JuridicalStatus = JuridicalStatus.Artificial;
            Rating = 8;
            DebtsSumm = 25.36d;
            ActiveOrders = 15;
            CustomerStatus = CustomerStatus.Active;
        }
        #endregion



    }
}
