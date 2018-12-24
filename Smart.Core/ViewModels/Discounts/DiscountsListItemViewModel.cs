using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="DiscountsListItemControl"> can display
    /// </summary>
    public class DiscountsListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected discount item
        /// </summary>
        private static DiscountsListItemViewModel mCurrentlySelectedDiscountItem = null;
        #endregion

        #region Public properties

        /// <summary>
        /// A number (or ID) of this discount
        /// </summary>
        public string DiscountNumber { get; set; }

        /// <summary>
        /// A name of this discount
        /// </summary>
        public string DiscountName { get; set; }
        
        
        /// <summary>
        /// A date this discount starts
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// A date this discount ends
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// A type of this discount
        /// </summary>
        public DiscountType DiscountType { get; set; }


        

        /// <summary>
        /// A minimum amount of this product (in case of a product discount)
        /// or minimum amount of a controlled product (in case of a bill discount)
        /// </summary>
        public int MinProductAmount { get; set; }

        /// <summary>
        /// A rate of this discount (percentage)
        /// </summary>
        public double DiscountRate { get; set; }

        /// <summary>
        /// A minimum amount of all products in BILL
        /// </summary>
        public int MinProductsAmountBill { get; set; }

        /// <summary>
        /// A minimum BILL summ for this discount
        /// </summary>
        public double MinSummBill { get; set; }
        
        /// <summary>
        /// A discount summ for this BILL
        /// </summary>
        public double DiscountSummBill { get; set; }

        /// <summary>
        /// An artnumber of the gift product for this discount
        /// </summary>
        public string DiscountGiftProductArtNumber { get; set; }

        /// <summary>
        /// A short name of the gift product to display
        /// </summary>
        public string DiscountGiftProductName { get; set; }

        /// <summary>
        /// The amount of the product, after which the discount is applied again
        /// </summary>
        public int? DiscountGiftDivisibilityCount { get; set; } = null;

        /// <summary>
        /// The amount of the product for the gift
        /// </summary>
        public int DiscountGiftProductAmount { get; set; } = 1;
        
        /// <summary>
        /// An art numer of the product this discount control in case of BILL discount
        /// </summary>
        public string ControlProductArtNumber { get; set; }
        
        /// <summary>
        /// Indicates if this discounts could be applied for any customer
        /// </summary>
        public bool IsCustomerCommon { get; set; }
        
        /// <summary>
        /// Indicates if this discounts could be applied for any product
        /// </summary>
        public bool IsProductCommon { get; set; }

        /// <summary>
        /// Names of products of this discount
        /// </summary>
        public List<string> ProductsNames { get; set; }

        /// <summary>
        /// Returns a string of products of this discount
        /// </summary>
        public string ProductsNamesString
        {
            get
            {
                if (IsProductCommon)
                    return "<все>";
                else
                {
                    string str = "";
                    foreach(var item in ProductsNames)
                    {
                        str = str.Insert(str.Length, $"{item}, ");
                    }
                    str = str.Remove(str.LastIndexOf(','), 2);
                    return str;
                }
            }
        }


        /// <summary>
        /// Names of customers of this discount
        /// </summary>
        public List<string> CustomersNames { get; set; }

        /// <summary>
        /// Returns a string of customers names of this discount
        /// </summary>
        public string CustomersNamesString
        {
            get
            {
                if (IsCustomerCommon)
                    return "<все>";
                else
                {
                    string str = "";
                    foreach (var item in CustomersNames)
                    {
                        str = str.Insert(str.Length, $"{item}, ");
                    }
                    str = str.Remove(str.LastIndexOf(','), 2);
                    return str;
                }
            }
        }
        /// <summary>
        /// Indicates if this discount item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;


        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this discount item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open current discount
        /// </summary>
        public ICommand OpenDiscountCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public DiscountsListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenDiscountCommand = new RelayCommand(OpenDiscount);

            //Hook into the CurrentDiscountNumberNullChanged event
            IoC.Discounts.CurrentDiscountNumberNullChanged += Unselect;
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected discount
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent discount item 
            if (mCurrentlySelectedDiscountItem != null)
                mCurrentlySelectedDiscountItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedDiscountItem = null;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// Selects current discount item
        /// </summary>
        private void Select()
        {
            //Try to get int value from the DiscountNumber string
            if (Int32.TryParse(DiscountNumber, out int discountNumber))
            {
                //Unselect previous discount item
                if (mCurrentlySelectedDiscountItem != null)
                    mCurrentlySelectedDiscountItem.IsSelected = false;
                //Sets a single instance of CurrentDiscountNumber to this discount's number


                IoC.Discounts.CurrentDiscountNumber = discountNumber;
                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedDiscountItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this discount number");

        }

        /// <summary>
        /// Opens curent discount item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenDiscount()
        {
            //Select this discount
            Select();

            //Ask shared view model to open currently selected discount
            IoC.Discounts.InfoDiscountCommand.Execute(null);

        }


        #endregion
    }
}
