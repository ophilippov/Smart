using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="SuppliersListControl"> can display
    /// </summary>
    public class SuppliersListDesignModel : SuppliersViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static SuppliersListDesignModel Instance => new SuppliersListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public SuppliersListDesignModel()
        {
            Suppliers = new List<SuppliersListItemViewModel>
            {
                new SuppliersListItemViewModel
                {
                     SupplierNumber = "1512152",
                     SupplierName = @"ОсИИ ""WD-40 distribution""",
                     DirectorName = "Самойлов А.П.",
                     JuridicalStatus = JuridicalStatus.Artificial,
                     DebtsSumm = 758.20d,
                     ActiveSupplies = 5,
                     SupplierStatus = SupplierStatus.Active
                },
                new SuppliersListItemViewModel
                {
                     SupplierNumber = "1512153",
                     SupplierName = @"ООО ""ИмпортерЮкрейнЛимитед""",
                     DirectorName = "Трандафилова К.А.",
                     JuridicalStatus = JuridicalStatus.Individual,
                     DebtsSumm = 0.10d,
                     ActiveSupplies = 2,
                     SupplierStatus = SupplierStatus.Inactive
                }
            };
        }
        #endregion



    }
}
