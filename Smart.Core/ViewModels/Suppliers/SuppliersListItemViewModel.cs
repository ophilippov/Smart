using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="SuppliersListItemControl"> can display
    /// </summary>
    public class SuppliersListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected supplier item
        /// </summary>
        private static SuppliersListItemViewModel mCurrentlySelectedSupplierItem = null;
        #endregion

        #region Public properties

        /// <summary>
        /// A number (or ID) of this supplier
        /// </summary>
        public string SupplierNumber { get; set; }

        /// <summary>
        /// A name of this supplier
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// A name of the director
        /// </summary>
        public string DirectorName { get; set; }

        /// <summary>
        /// A juridical status of this supplier
        /// </summary>
        public JuridicalStatus JuridicalStatus { get; set; }

        /// <summary>
        /// A status of this supplier
        /// </summary>
        public SupplierStatus SupplierStatus { get; set; }

        /// <summary>
        /// This company debt for this supplier
        /// </summary>
        public double DebtsSumm { get; set; }

       
        /// <summary>
        /// A namber of active supplies of this supplier
        /// </summary>
        public int ActiveSupplies{ get; set; }

        /// <summary>
        /// Indicates if this supplier item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;


        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this supplier item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open current supplier
        /// </summary>
        public ICommand OpenSupplierCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SuppliersListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenSupplierCommand = new RelayCommand(OpenSupplier);

            //Hook into the CurrentSupplierNumberNullChanged event
            IoC.Suppliers.CurrentSupplierNumberNullChanged += Unselect;
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected supplier
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent supplier item 
            if (mCurrentlySelectedSupplierItem != null)
                mCurrentlySelectedSupplierItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedSupplierItem = null;

        }
        #endregion

        #region Command Methods

        /// <summary>
        /// Selects current supplier item
        /// </summary>
        private void Select()
        {
            //Try to get int value from the SupplierNumber string
            if (Int32.TryParse(SupplierNumber, out int supplierNumber))
            {
                //Unselect previous supplier item
                if (mCurrentlySelectedSupplierItem != null)
                    mCurrentlySelectedSupplierItem.IsSelected = false;

                //Sets a single instance of CurrentSupplierNumber to this supplier's number


                IoC.Suppliers.CurrentSupplierNumber = supplierNumber;

                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedSupplierItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this supplier number");

        }

        /// <summary>
        /// Opens curent supplier item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenSupplier()
        {
            //Select this supplier
            Select();

            //Ask shared view model to open currently selected supplier
            IoC.Suppliers.InfoSupplierCommand.Execute(null);

        }


        #endregion
    }
}
