using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="ProductsListItemControl"> can display
    /// </summary>
    public class ProductsListItemDesignModel:ProductsListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static ProductsListItemDesignModel Instance => new ProductsListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public ProductsListItemDesignModel()
        {
            Name = "WD-40, 150мл";
            Description = "WD-40, 150мл, SmartStraw. Аэрозольная водоотталкивающая смазка";
            ArtNumber = "1234567890";
            Amount = 20;
            MinAmount = 1;
            DiscountCount = 3;
            ThumbnailImagePath = @"/Images/Samples/WD-40.png";
            PriceUAH = 45.60d;
            PriceUSD = 2.1d;
            WholeSalePriceUAH = 35.30d;
            WholeSalePriceUSD = 1.3d;
            
        }
        #endregion



    }
}
