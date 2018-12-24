using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="ProductsListControl"> can display
    /// </summary>
    public class ProductsListDesignModel : ProductsViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static ProductsListDesignModel Instance => new ProductsListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public ProductsListDesignModel()
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
                };
        }
        #endregion



    }
}
