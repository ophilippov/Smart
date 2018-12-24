

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Smart.Core
{
    /// <summary>
    /// Configures the application according to the currently selected category (menu tab) 
    /// </summary>
    public static class AppConfigure
    {


        /// <summary>
        /// Configures application to work with orders (manager)
        /// </summary>
        public static void OrdersConfigure()
        {
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.ManagerOrders, new OrdersViewModel()
            {
                //TODO: replace this dummy data with actual data
                Orders = new List<OrdersListItemViewModel>
                {
                    new OrdersListItemViewModel
                    {
                        Name = "Филиппов Олег Анатольевич",
                        OrderStatus = OrderStatus.Closed,
                        PaymentStatus = PaymentStatus.Overdue,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123456",
                        PaymentAmount = 612.80d,
                        Price = 820.10d
                    },

                    new OrdersListItemViewModel
                    {
                        Name = "Кулмамадов Владислав Давлатмуродович",
                        OrderStatus = OrderStatus.ManagerProcessing,
                        PaymentStatus = PaymentStatus.Paid,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123466",
                        PaymentAmount = 0.00d,
                        Price = 25.50d
                    },

                    new OrdersListItemViewModel
                    {
                        Name = "Черба Елена Анатольевна",
                        OrderStatus = OrderStatus.StockProcessing,
                        PaymentStatus = PaymentStatus.PaidForPart,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123456",
                        PaymentAmount = 20.00d,
                        Price = 1362.46d
                    },

                    new OrdersListItemViewModel
                    {
                        Name = "Белов Игорь Игоревич",
                        OrderStatus = OrderStatus.Cancelled,
                        PaymentStatus = PaymentStatus.ReturningMoney,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "121256",
                        PaymentAmount = 0.00d,
                        Price = 156.90d
                    },



                }
            });
            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.ManagerSearch);
            //Unselect currently selected order
            IoC.Manager.CurrentOrderNumber = null;
        }

        /// <summary>
        /// Configures application to work with stock
        /// </summary>
        public static void StockConfigure()
        {
            switch (IoC.Stock.CurrentCategory)
            {
                //TODO: complete this selection
                case StockCategory.Orders:
                    StockOrdersConfigure(); break;
                case StockCategory.Products:
                    StockProductsConfigure(); break;
                case StockCategory.Supplies:
                    StockSuppliesConfigure(); break;
                case StockCategory.WriteOffs:
                    StockWriteOffsConfigure(); break;
                default:
                    Debugger.Break(); break;

            }

        }

        /// <summary>
        /// Configures application to work with discounts
        /// </summary>
        public static void DiscountsConfigure()
        {
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.Discounts, new DiscountsViewModel()
            {
                //TODO: replace this dummy data with actual data
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
                    MinSummBill = 8500000d,
                    MinProductAmount = 9,
                    DiscountSummBill = 99d,
                    IsCustomerCommon = true,
                    IsProductCommon = false,
                    ProductsNames= new List<string>{"Лучшая смазка"},
                    ControlProductArtNumber="12856516"
                }


                }
            });
            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.ManagerSearch);
            //Unselect currently selected discount
            IoC.Discounts.CurrentDiscountNumber = null;
        }


        /// <summary>
        /// Configures application to work with customers
        /// </summary>
        public static void CustomersConfigure()
        {
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.Customers, new CustomersViewModel()
            {
                //TODO: replace this dummy data with actual data
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
                         CustomerStatus = CustomerStatus.Active,
                    },
                    new CustomersListItemViewModel
                    {
                         CustomerNumber = "1512153",
                         CustomerName = @"ООО ""Инвестбуд""",
                         DirectorName = "Сапожников К.Л.",
                         JuridicalStatus = JuridicalStatus.Individual,
                         Rating = -9,
                         DebtsSumm = 159996.10d,
                         ActiveOrders = 6,
                         CustomerStatus = CustomerStatus.Inactive
                    }
                }
        });
            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.None);
            //Unselect currently selected customer
            IoC.Customers.CurrentCustomerNumber = null;
        }

        /// <summary>
        /// Configures application to work with suppliers
        /// </summary>
        public static void SuppliersConfigure()
        {
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.Suppliers, new SuppliersViewModel()
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
                }
        });
            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.None);
            //Unselect currently selected customer
            IoC.Suppliers.CurrentSupplierNumber = null;
        }

        #region Private Helpers

        /// <summary>
        /// Configures application to work with orders (Stock)
        /// </summary>
        private static void StockOrdersConfigure()
        {
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.StockOrders, new StockOrdersViewModel()
            {
                //TODO: replace this dummy data with actual data
                Orders = new List<StockOrdersListItemViewModel>
                {
                    new StockOrdersListItemViewModel
                    {
                        Name = "Филиппов Олег Анатольевич",
                        OrderStatus = OrderStatus.StockApproved,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123456",
                        Price = 612.80d,
                    },

                    new StockOrdersListItemViewModel
                    {
                        Name = "Кулмамадов Владислав Давлатмуродович",
                        OrderStatus = OrderStatus.StockProcessing,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123466",
                        Price = 25d
                    },

                    new StockOrdersListItemViewModel
                    {
                       Name = "Черба Елена Анатольевна",
                       OrderStatus = OrderStatus.StockRejected,
                       OrderDate = DateTime.UtcNow.Date,
                       OrderNumber = "123456",
                       Price = 20d
                    },

                    new StockOrdersListItemViewModel
                    {
                        Name = "Гайдаржи Николай Николаевич",
                        OrderStatus = OrderStatus.TransferedToSC,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "123456",
                        Price = 520.15d
                    },

                    new StockOrdersListItemViewModel
                    {
                        Name = "Белов Игорь Игоревич",
                        OrderStatus = OrderStatus.StockDepartured,
                        OrderDate = DateTime.UtcNow.Date,
                        OrderNumber = "121256",
                        Price = 58.2d
                    }



                }
            });
            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.None);
            //Unselect currently selected order
            IoC.Stock.CurrentOrderNumber = null;
        }

        /// <summary>
        /// Configures application to work with products (Stock)
        /// </summary>
        private static void StockProductsConfigure()
        {
            //TODO: replace this dummy data with actual data 
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.StockProducts, new ProductsViewModel
            {

                Products = new List<ProductsListItemViewModel>
                {
                    new ProductsListItemViewModel
                    {
                        Name = "WD-40, 150мл",
                        Description = "WD-40, 150мл, SmartStraw. Аэрозольная водоотталкивающая смазка",
                        ArtNumber = "1234567894",
                        Amount = 0,
                        DiscountCount = 0,
                        ThumbnailImagePath = @"/Images/Samples/WD-40.png",
                        PriceUAH = 45.60d,
                        PriceUSD = 2.1d,
                        WholeSalePriceUAH = 35.30d,
                        WholeSalePriceUSD = 1.3d,
                        MinAmount=2
                    },
                    new ProductsListItemViewModel
                    {
                       Name = "Fairy, 1л",
                       Description = "Средство для мытья посуды с ароматом яблока и экстрактом алоэ вера",
                       ArtNumber = "1234567895",
                       Amount = 6,
                       DiscountCount = 3,
                       ThumbnailImagePath = @"/Images/Samples/fairy.jpg",
                       PriceUAH = 45.60d,
                       PriceUSD = 2.1d,
                       WholeSalePriceUAH = 35.30d,
                       WholeSalePriceUSD = 1.3d,
                       MinAmount=0
                    },
                    new ProductsListItemViewModel
                    {
                      Name = "Domestos, 1л",
                      Description = "Чистящее средство. Ультра белый",
                      ArtNumber = "1234567896",
                      Amount = 10,
                      DiscountCount = 0,
                      ThumbnailImagePath = @"/Images/Samples/domestos-gr.png",
                      PriceUAH = 45.60d,
                      PriceUSD = 2.1d,
                      WholeSalePriceUAH = 35.30d,
                      WholeSalePriceUSD = 1.3d,
                      MinAmount=10
                    },
                    new ProductsListItemViewModel
                    {
                      Name = "Domestos, 1л",
                      Description = "Чистящее средство. Ультра белый",
                      ArtNumber = "1234567897",
                      Amount = 40,
                      DiscountCount = 3,
                      ThumbnailImagePath = @"/Images/Samples/domestos-pur.png",
                      PriceUAH = 45.60d,
                      PriceUSD = 2.1d,
                      WholeSalePriceUAH = 35.30d,
                      WholeSalePriceUSD = 1.3d,
                      MinAmount=2
                    },
                    new ProductsListItemViewModel
                    {
                      Name = "Domestos, 1л",
                      Description = "Чистящее средство. Ультра белый",
                      ArtNumber = "1234567898",
                      Amount = 1,
                      DiscountCount = 3,
                      ThumbnailImagePath = @"/Images/Samples/domestos-wt.jpeg",
                      PriceUAH = 45.60d,
                      PriceUSD = 2.1d,
                      WholeSalePriceUAH = 35.30d,
                      WholeSalePriceUSD = 1.3d,
                      MinAmount=20
                    }
                }
            });

            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.ManagerSearch);
            //Unselect currently selected product
            IoC.Stock.CurrentProductArtNumber = null;
        }

        /// <summary>
        /// Configures application to work with supplies (Stock)
        /// </summary>
        private static void StockSuppliesConfigure()
        {
            //TODO: replace this dummy data with actual data ABOUT SUPPLIES
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.StockSupplies, new SuppliesViewModel
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
                        PaymentAmount = 0d,
                        PaymentStatus = PaymentStatus.Paid,
                        SupplyStatus = SupplyStatus.Done,
                        Price = 204522.48,
                        SupplyNumber = "01233514",
                        SupplyCreationDate = DateTime.UtcNow.Date
                    },
                }


            });

            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.ManagerSearch);
            //Unselect currently selected supply
            IoC.Stock.CurrentSupplyNumber = null;
        }

        /// <summary>
        /// Configures application to work with write-offs (Stock)
        /// </summary>
        private static void StockWriteOffsConfigure()
        {
            //TODO: replace this dummy data with actual data ABOUT Write-offs
            //Open main window
            IoC.Application.GoToPageMain(ApplicationPage.StockWriteOffs, new WriteOffsViewModel
            {
                WriteOffs = new List<WriteOffsListItemViewModel>
                {
                    new WriteOffsListItemViewModel
                    {
                        WriteOffNumber = "123562221",
                        Price = 250.1d,
                        Status = WriteOffStatus.NewWriteOff,
                        CreationDate = DateTime.UtcNow.Date,
                        ItemsCount = 25
                    },
                    new WriteOffsListItemViewModel
                    {
                        WriteOffNumber = "123562222",
                        Price = 26.0d,
                        Status = WriteOffStatus.Cancelled,
                        CreationDate = DateTime.UtcNow.Date,
                        ItemsCount = 5
                    },
                    new WriteOffsListItemViewModel
                    {
                        WriteOffNumber = "123562223",
                        Price = 985.79d,
                        Status = WriteOffStatus.Done,
                        CreationDate = DateTime.UtcNow.Date,
                        ItemsCount = 120
                    },
                    new WriteOffsListItemViewModel
                    {
                        WriteOffNumber = "123562224",
                        Price = 10.25d,
                        Status = WriteOffStatus.Done,
                        CreationDate = DateTime.UtcNow.Date,
                        ItemsCount = 2
                    }

                }
            });

            //Open additional window
            IoC.Application.GoToPageAdditional(ApplicationPage.ManagerSearch);
            //Unselect currently selected supply
            IoC.Stock.CurrentWriteOffNumber = null;
        } 
        #endregion
    }
}
