using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="SuppliesListControl"> can display
    /// </summary>
    public class SuppliesListDesignModel : SuppliesViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static SuppliesListDesignModel Instance => new SuppliesListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public SuppliesListDesignModel()
        {
            Supplies = new List<SuppliesListItemViewModel>
            {
                new SuppliesListItemViewModel
                {
                    CompanyName = @"ПАО ""ОдессаЮгСтрой""",
                    PaymentAmount = 252.5d,
                    PaymentStatus = PaymentStatus.Overdue,
                    SupplyStatus = SupplyStatus.Done,
                    Price = 1256.80d,
                    SupplyNumber = "01233511",
                    SupplyCreationDate = DateTime.UtcNow.Date
                },
                new SuppliesListItemViewModel
                {
                    CompanyName = @"ФЛП ""Копытов А.И.""",
                    PaymentAmount = 252.5d,
                    PaymentStatus = PaymentStatus.PaidForPart,
                    SupplyStatus = SupplyStatus.Waiting,
                    Price = 256.80d,
                    SupplyNumber = "01233512",
                    SupplyCreationDate = DateTime.UtcNow.Date
                },
                 new SuppliesListItemViewModel
                {
                    CompanyName = @"ООО ""Хенкель Баутехник Украина""",
                    PaymentAmount = 45.2d,
                    PaymentStatus = PaymentStatus.WaitingForPayment,
                    SupplyStatus = SupplyStatus.NewSupply,
                    Price = 2000.52d,
                    SupplyNumber = "01233513",
                    SupplyCreationDate = DateTime.UtcNow.Date
                },
                  new SuppliesListItemViewModel
                {
                    CompanyName = @"ПрАО ""КаллибрусЮг""",
                    PaymentAmount = 0.0d,
                    PaymentStatus = PaymentStatus.Paid,
                    SupplyStatus = SupplyStatus.Done,
                    Price = 204522.48,
                    SupplyNumber = "01233514",
                    SupplyCreationDate = DateTime.UtcNow.Date
                },
            };
        }
        #endregion



    }
}
