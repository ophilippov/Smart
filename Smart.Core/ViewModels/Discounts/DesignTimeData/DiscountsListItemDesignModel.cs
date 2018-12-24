using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="DiscountsListItemControl"> can display
    /// </summary>
    public class DiscountsListItemDesignModel:DiscountsListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static DiscountsListItemDesignModel Instance => new DiscountsListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public DiscountsListItemDesignModel()
        {
            DiscountNumber = "01225636";
            DiscountName = "Рвем Цены";
            StartDate = DateTime.UtcNow.Date;
            EndDate = DateTime.UtcNow.Date;
            MinProductAmount = 2;
            DiscountRate = 25d;
            DiscountType = DiscountType.ProductPercentAll;
            IsCustomerCommon = false;
            IsProductCommon = false;
            MinProductsAmountBill = 26;
            MinSummBill = 1000d;
            DiscountSummBill = 200d;
            DiscountGiftProductArtNumber = "121151654";
            DiscountGiftProductAmount = 1;
            DiscountGiftDivisibilityCount = null;
            DiscountGiftProductName = "Domestos";
            ControlProductArtNumber = "1384164687";
            CustomersNames = new List<string>
            {
                "Филиппов О.А.",
                "Бойко В.В",
                "Черба Е.А.",
                "Кулмамадов В.Д."
            };
            ProductsNames = new List<string>
            {
                "WD-40",
                "Чай черный ЕрлГрей",
                "Domestos UltraWhite",
                "Fairy OxyFresh"
            };


        }
        #endregion



    }
}
