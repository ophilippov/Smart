using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="DiscountsListControl"> can display
    /// </summary>
    public class DiscountsListDesignModel : DiscountsViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static DiscountsListDesignModel Instance => new DiscountsListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public DiscountsListDesignModel()
        {
            Discounts = new List<DiscountsListItemViewModel>
            {
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01225636",
                    DiscountName = "Рвем Цены",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductAmount = 2,
                    DiscountRate = 22d,
                    DiscountType = DiscountType.ProductPercentOne,
                    IsCustomerCommon = false,
                    IsProductCommon = false,
                    CustomersNames = new List<string>
                    {
                        "Филиппов О.А.",
                        "Бойко В.В",
                        "Черба Е.А.",
                        "Кулмамадов В.Д."
                    },
                    ProductsNames = new List<string>
                    {
                        "WD-40",
                        "Чай черный ЕрлГрей",
                        "Domestos UltraWhite",
                        "Fairy OxyFresh"
                    }
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01228936",
                    DiscountName = "Рвем Цены",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductAmount = 5,
                    DiscountRate = 50d,
                    DiscountType = DiscountType.ProductPercentAll,
                    IsCustomerCommon = false,
                    IsProductCommon = true,
                    CustomersNames = new List<string>
                    {
                        "Филиппов О.А."
                    }
                   
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01225637",
                    DiscountName = "Новая акция",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductAmount = 15,
                    DiscountType = DiscountType.ProductGift,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    DiscountGiftProductName="Fairy Oxy",
                    DiscountGiftProductArtNumber="115615615",
                    ProductsNames = new List<string>
                    {
                        "WD-40",
                        "Чай черный ЕрлГрей",
                        "Domestos UltraWhite",
                        "Fairy OxyFresh"
                    }
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01225638",
                    DiscountName = "Какая-то акция",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductsAmountBill = 120,
                    DiscountRate = 15d,
                    DiscountType = DiscountType.BillPercentMinCount,
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01025638",
                    DiscountName = "Шара",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountRate = 43d,
                    DiscountType = DiscountType.BillPercentBillSumm,
                    MinSummBill = 120d,
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01026638",
                    DiscountName = "Скидочка",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountRate = 43d,
                    DiscountType = DiscountType.BillPercentMinProductCount,
                    MinProductAmount = 10,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"WD-40"},
                    ControlProductArtNumber="12156516516"
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01026648",
                    DiscountName = "Обвал цен",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountRate = 35d,
                    DiscountType = DiscountType.BillPercentBillSummMinProductCount,
                    MinSummBill = 500d,
                    MinProductAmount = 6,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"WD-40"},
                    ControlProductArtNumber="121516516"
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01525638",
                    DiscountName = "Акция!!!",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductsAmountBill = 20,
                    DiscountGiftProductArtNumber="15165165",
                    DiscountGiftProductName = "Domestos",
                    DiscountType = DiscountType.BillGiftMinCount,
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01135638",
                    DiscountName = "Сумасшедшие скидки",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillGiftBillSumm,
                    MinSummBill = 500d,
                    DiscountGiftProductName="Gala",
                    DiscountGiftProductArtNumber="251651561",
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01026690",
                    DiscountName = "Скидка!!!",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillGiftMinProductCount,
                    MinProductAmount = 16,
                    DiscountGiftProductArtNumber="15613555",
                    DiscountGiftProductName="Fairy Oxy Fresh",
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"Gala"},
                    ControlProductArtNumber="12151516"
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01078648",
                    DiscountName = "Обвал цен",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillGiftBillSummMinProductCount,
                    MinSummBill = 850d,
                    MinProductAmount = 3,
                    DiscountGiftProductName="Domestos Ultra",
                    DiscountGiftProductArtNumber = "155852566",
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"Fairy Oxy"},
                    ControlProductArtNumber="121516516"
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01525649",
                    DiscountName = "Ликвидация склада!",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    MinProductsAmountBill = 200,
                    DiscountType = DiscountType.BillSummMinCount,
                    DiscountSummBill=100d,
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01135788",
                    DiscountName = "Новые скидки",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillSummBillSumm,
                    DiscountSummBill=50d,
                    MinSummBill = 850d,
                    IsCustomerCommon = true,
                    IsProductCommon = true
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01156690",
                    DiscountName = "Распродажа!!!",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillSummMinProductCount,
                    MinProductAmount = 56,
                    DiscountSummBill = 291d,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"Чай Ерл Грей"},
                    ControlProductArtNumber="12115516"
                },
                new DiscountsListItemViewModel
                {
                    DiscountNumber = "01077858",
                    DiscountName = "Длинннонннннное иииииммммя",
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    DiscountType = DiscountType.BillSummBillSummMinProductCount,
                    MinSummBill = 850d,
                    MinProductAmount = 9,
                    DiscountSummBill = 99d,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"Лучшая смазка"},
                    ControlProductArtNumber="12856516"
                }


            };
        }
        #endregion



    }
}
