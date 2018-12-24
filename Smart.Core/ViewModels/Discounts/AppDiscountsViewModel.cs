using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// ViewModel for the Discounts item of the TabMenu
    /// </summary>
    public class AppDiscountsViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Number of the currently selected discount
        /// </summary>
        private int? mCurrentDiscountNumber = null;
        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires when current discount changes to null
        /// </summary>
        public event Action CurrentDiscountNumberNullChanged;
        #endregion

        #region Public commands

        /// <summary>
        /// The command to create a new discount
        /// </summary>
        public ICommand NewDiscountCommand { get; set; }

        /// <summary>
        /// The command to edit this discount
        /// </summary>
        public ICommand EditDiscountCommand { get; set; }

        /// <summary>
        /// The command to delete this discount
        /// </summary>
        public ICommand DeleteDiscountCommand { get; set; }

        /// <summary>
        /// The command to get info about this discount
        /// </summary>
        public ICommand InfoDiscountCommand { get; set; }

        /// <summary>
        /// The command to get info about customers for whom this discount can be applied
        /// </summary>
        public ICommand CustomersInfoDiscountCommand { get; set; }

        /// <summary>
        /// The command to get info about products for which this discount can be applied
        /// </summary>
        public ICommand ProductsInfoDiscountCommand { get; set; }

        /// <summary>
        /// A command to set a sorting order
        /// </summary>
        public ICommand SortDiscountCommand { get; set; }
        #endregion

        #region Public Properties

        /// <summary>
        /// Number of all discounts
        /// </summary>
        public int AllDiscountsCount { get; set; }

        /// <summary>
        /// Number of active discounts
        /// </summary>
        public int ActiveDiscountsCount { get; set; }

        /// <summary>
        /// Number of inactive discounts
        /// </summary>
        public int InactiveDiscountsCount { get; set; }

        /// <summary>
        /// Number of personal discounts
        /// </summary>
        public int PersonalDiscountsCount { get; set; }

        /// <summary>
        /// Number of public discounts
        /// </summary>
        public int PublicDiscountsCount { get; set; }

        /// <summary>
        /// Number of price discounts
        /// </summary>
        public int PriceDiscountsCount { get; set; }

        /// <summary>
        /// Number of gift discounts
        /// </summary>
        public int GiftDiscountsCount { get; set; }

        /// <summary>
        /// Number of discounts for all products
        /// </summary>
        public int AllProductsDiscountsCount { get; set; }

        /// <summary>
        /// Number of discounts for single products
        /// </summary>
        public int SingleProductsDiscountsCount { get; set; }

        /// <summary>
        /// Number of the currently selected discount
        /// </summary>
        public int? CurrentDiscountNumber {
            get => mCurrentDiscountNumber;
            set
            {
                mCurrentDiscountNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentDiscountNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// A sorting order for discounts
        /// </summary>
        public DiscountSortBy DiscountSortBy { get; set; } = DiscountSortBy.Name;

        /// <summary>
        /// Sets wich discounts must be shown
        /// </summary>
        public DiscountShow DiscountShow { get; set; } = DiscountShow.AllDiscounts;

        /// <summary>
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingType { get; set; } = false;

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppDiscountsViewModel()
        {
            //Initialize all commands for discounts
            NewDiscountCommand = new RelayCommand(NewDiscount);
            EditDiscountCommand = new RelayCommand(EditDiscount);
            DeleteDiscountCommand = new RelayCommand(DeleteDiscount);
            InfoDiscountCommand = new RelayCommand(InfoDiscount);
            ProductsInfoDiscountCommand = new RelayCommand(ProductsInfoDiscount);
            CustomersInfoDiscountCommand = new RelayCommand(CustomersInfoDiscount);
            SortDiscountCommand = new RelayCommand(SortDiscount);
           
            //Get summary about discounts
            GetSummary();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets summary about discounts
        /// </summary>
        private void GetSummary()
        {
            //TODO: gets summary about discounts
        }

        #endregion

        #region Commands helpers

        /// <summary>
        /// Creates a new discount
        /// </summary>
        private void NewDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits currently selected discount
        /// </summary>
        private void EditDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes currently selected discount
        /// </summary>
        private void DeleteDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows an info about current discount
        /// </summary>
        private void InfoDiscount()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущая акция",
                Message = $"Текущая выбранная акция: {CurrentDiscountNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }

        /// <summary>
        /// Shows an info about products for which this discount can be applied
        /// </summary>
        private void ProductsInfoDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows an info about customers for whom this discount can be applied
        /// </summary>
        private void CustomersInfoDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a sorting order 
        /// </summary>
        private void SortDiscount()
        {
            //Inverts a current value of SortingType
            SortingType ^= true;
        }
        #endregion

    }

}
