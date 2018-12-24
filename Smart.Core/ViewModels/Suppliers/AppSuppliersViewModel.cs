using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// ViewModel for the Suppliers item of the TabMenu
    /// </summary>
    public class AppSuppliersViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Number of the currently selected supplier
        /// </summary>
        private int? mCurrentSupplierNumber = null;
        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires when current supplier changes to null
        /// </summary>
        public event Action CurrentSupplierNumberNullChanged;
        #endregion

        #region Public commands

        /// <summary>
        /// The command to create a new supplier
        /// </summary>
        public ICommand NewSupplierCommand { get; set; }

        /// <summary>
        /// The command to edit currently selected supplier
        /// </summary>
        public ICommand EditSupplierCommand { get; set; }
        
        /// <summary>
        /// The command to delete currently selected supplier
        /// </summary>
        public ICommand DeleteSupplierCommand { get; set; }

        /// <summary>
        /// The command to get info about currently selected supplier
        /// </summary>
        public ICommand InfoSupplierCommand { get; set; }

        /// <summary>
        /// The command to print info about currently selected supplier
        /// </summary>
        public ICommand PrintSupplierCommand { get; set; }

        /// <summary>
        /// The command to get info about supplies of the currently selected supplier
        /// </summary>
        public ICommand InfoSupplySupplierCommand { get; set; }

        
        /// <summary>
        /// The command to get info about my payments for the currently selected supplier
        /// </summary>
        public ICommand InfoPaymentsSupplierCommand { get; set; }


        /// <summary>
        /// A command to set a sorting order
        /// </summary>
        public ICommand SortSupplierCommand { get; set; }
        #endregion

        #region Public Properties

        /// <summary>
        /// Number of all suppliers
        /// </summary>
        public int AllSuppliersCount { get; set; }

        /// <summary>
        /// Number of all artificial suppliers
        /// </summary>
        public int ArtificialSuppliersCount { get; set; }

        /// <summary>
        /// Number of all individual suppliers 
        /// 
        /// /// </summary>
        public int IndividualSuppliersCount { get; set; }

        /// <summary>
        /// Number of active suppliers
        /// </summary>
        public int ActiveSuppliersCount { get; set; }

        /// <summary>
        /// Number of inactive suppliers
        /// </summary>
        public int InactiveSuppliersCount { get; set; }
        

        /// <summary>
        /// Number of suppliers for whom this company have debts
        /// </summary>
        public int CreditorsSuppliersCount { get; set; }


        /// <summary>
        /// Number of the currently selected supplier
        /// </summary>
        public int? CurrentSupplierNumber {
            get => mCurrentSupplierNumber;
            set
            {
                mCurrentSupplierNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentSupplierNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// A sorting order for suppliers
        /// </summary>
        public SupplierSortBy SupplierSortBy { get; set; } = SupplierSortBy.SupplierName;

        /// <summary>
        /// Sets wich suppliers must be shown
        /// </summary>
        public SupplierShow SupplierShow { get; set; } = SupplierShow.AllSuppliers;

        /// <summary>
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingType { get; set; } = false;

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppSuppliersViewModel()
        {
            //Initialize all commands for discounts

            NewSupplierCommand = new RelayCommand(NewSupplier);
            EditSupplierCommand = new RelayCommand(EditSupplier);
            DeleteSupplierCommand = new RelayCommand(DeleteSupplier);
            PrintSupplierCommand = new RelayCommand(PrintSupplier);
            InfoSupplySupplierCommand = new RelayCommand(InfoSupplySupplier);
            InfoSupplierCommand = new RelayCommand(InfoSupplier);
            SortSupplierCommand = new RelayCommand(SortSupplier);
            InfoPaymentsSupplierCommand = new RelayCommand(InfoPaymentsSupplier);
           
            //Get summary about suppliers
            GetSummary();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets summary about suppliers
        /// </summary>
        private void GetSummary()
        {
            //TODO: gets summary about suppliers
        }

        #endregion

        #region Commands helpers

        /// <summary>
        /// Creates a new supplier
        /// </summary>
        private void NewSupplier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits info about the currently selected supplier
        /// </summary>
        private void EditSupplier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the currently selected supplier
        /// </summary>
        private void DeleteSupplier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the currently selected supplier
        /// </summary>
        private void InfoSupplier()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущий поставщик",
                Message = $"Текущий выбранный поставщик: {CurrentSupplierNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }
    

        /// <summary>
        /// Shows info about the currently selected supplier's payments
        /// </summary>
        private void InfoPaymentsSupplier()
        {
            throw new NotImplementedException();
        }

      

        /// <summary>
        /// Shows info about the currently selected supplier's supplies
        /// </summary>
        private void InfoSupplySupplier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints info about the currently selected supplier
        /// </summary>
        private void PrintSupplier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a sorting order 
        /// </summary>
        private void SortSupplier()
        {
            //Inverts a current value of SortingType
            SortingType ^= true;
        }
        #endregion

    }

}
