using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Suppliers page
    /// </summary>
    public class SuppliersViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// A command to unselect any supplier
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public SuppliersViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The suppliers list items for the list
        /// </summary>
        public List<SuppliersListItemViewModel> Suppliers { get; set; } = null;

        /// <summary>
        /// Indicates if the Suppliers list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Suppliers == null || Suppliers.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        /// <summary>
        /// Unseletcs currently selected supplier
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected supplier item
            IoC.Suppliers.CurrentSupplierNumber = null; 
            
        }
        #endregion

    }
}
