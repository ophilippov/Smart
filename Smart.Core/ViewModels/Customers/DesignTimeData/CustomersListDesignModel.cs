using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="CustomersListControl"> can display
    /// </summary>
    public class CustomersListDesignModel : CustomersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static CustomersListDesignModel Instance => new CustomersListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public CustomersListDesignModel()
        {
            Customers = new List<CustomersListItemViewModel>
            {
                new CustomersListItemViewModel
                {
                     CustomerNumber = "1512152",
                     CustomerName = @"ПрАО ""ОдессаСтальКанат""",
                     DirectorName = "Дегтярев А.И.",
                     JuridicalStatus = JuridicalStatus.Artificial,
                     Rating = 8,
                     DebtsSumm = 25.36d,
                     ActiveOrders = 15,
                     CustomerStatus = CustomerStatus.Active
                },
                new CustomersListItemViewModel
                {
                     CustomerNumber = "1512153",
                     CustomerName = @"ООО ""Инвестбуд""",
                     DirectorName = "Сапожников К.Л.",
                     JuridicalStatus = JuridicalStatus.Individual,
                     Rating = -1,
                     DebtsSumm = 159996.10d,
                     ActiveOrders = 6,
                     CustomerStatus = CustomerStatus.Inactive
                }
            };
        }
        #endregion



    }
}
