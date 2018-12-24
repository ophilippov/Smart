using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="ProductsListItemControl"> can display
    /// </summary>
    public class ProductsListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected product item
        /// </summary>
        private static ProductsListItemViewModel mCurrentlySelectedProductItem = null;

        /// <summary>
        /// A full path to the image of this product
        /// </summary>
        private string mThumbnailImagePath;
        #endregion

        #region Public properties



        /// <summary>
        /// The name of this product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A description of this product
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The artNumber of this product
        /// </summary>
        public string ArtNumber { get; set; }

        /// <summary>
        /// Amount of this product in stock
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Minimum amount of this product
        /// </summary>
        public int MinAmount { get; set; }

        /// <summary>
        /// Returns tru if this product is ending in a stock
        /// </summary>
        public bool IsEnding => Amount < MinAmount; 

        /// <summary>
        /// Number of discounts this product is participating in
        /// </summary>
        public int DiscountCount { get; set; }

        /// <summary>
        /// A full path to the image of this product
        /// </summary>
        public string ThumbnailImagePath
        {
            get =>  mThumbnailImagePath;
            set
            {
                if (mThumbnailImagePath == value)
                    return;

                mThumbnailImagePath = value;
                //TODO: get the image from the server/storage
                //      set up ThumbnailLocalPath

                //NOTE: let now the local path = full path
                //Mimic some waiting...
                
                Task.Delay(3000).ContinueWith(t => ThumbnailImageLocalPath = value);
                //ThumbnailImageLocalPath = value;

            }
        }

        /// <summary>
        /// A local path to the image of this product
        /// </summary>
        public string ThumbnailImageLocalPath { get; set; }

        /// <summary>
        /// Indicates whether an image is already downloaded or not
        /// </summary>
        public bool ImageLoaded => !String.IsNullOrEmpty(ThumbnailImageLocalPath);

        /// <summary>
        /// The wholesale price of this product in UAH
        /// </summary>
        public double WholeSalePriceUAH { get; set; }

        /// <summary>
        /// The wholesale price of this product in USD
        /// </summary>
        public double WholeSalePriceUSD { get; set; }

        /// <summary>
        /// The price of this product in UAH
        /// </summary>
        public double PriceUAH { get; set; }

        /// <summary>
        /// The price of this product in USD
        /// </summary>
        public double PriceUSD { get; set; }

        /// <summary>
        /// Indicates whether this product is selected or not.
        /// </summary>
        public bool IsSelected { get; private set; } = false;


        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this order item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open this product
        /// </summary>
        public ICommand OpenProductCommand { get; set; }

        /// <summary>
        /// A command to request a supply for this product
        /// </summary>
        public ICommand SupplyRequestCommand { get; set; }
        

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductsListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            SupplyRequestCommand = new RelayCommand(SupplyRequest);
            OpenProductCommand = new RelayCommand(OpenProduct);

            //Hook into the CurrentProductArtNumberNullChanged event
            IoC.Stock.CurrentProductArtNumberNullChanged += Unselect;
        }
        #endregion


        #region Private Helpers

        /// <summary>
        /// Unselects currently selected product
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent product item 
            if (mCurrentlySelectedProductItem != null)
                mCurrentlySelectedProductItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedProductItem = null;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// Selects current product item
        /// </summary>
        private void Select()
        {
            //Try to get int value from the OrderNumber string
            if (Int32.TryParse(ArtNumber, out int artNumber))
            {
                //Unselect previous order item
                if (mCurrentlySelectedProductItem != null)
                    mCurrentlySelectedProductItem.IsSelected = false;

                //Sets a single instance of CurrentProductArtNumber to this product's number
                IoC.Stock.CurrentProductArtNumber = artNumber;

                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedProductItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize the art number of this product");

        }

        /// <summary>
        /// Opens curent product item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenProduct()
        {
            //Select this product
            Select();

            //Ask shared view model to open currently selected product
            IoC.Stock.InfoProductCommand.Execute(null);

        }

        /// <summary>
        /// Requests a supply for this product
        /// </summary>
        private void SupplyRequest()
        {
            //TODO: Add this product to a new supply request
            Debugger.Break();

        }

        #endregion
    }
}
