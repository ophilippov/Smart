using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Stock supplies page
    /// </summary>
    public class SuppliesViewModel : BaseViewModel
    {

        #region Public Commands

        /// <summary>
        /// A command to unselect any supply
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public SuppliesViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The supplies list items for the list
        /// </summary>
        public List<SuppliesListItemViewModel> Supplies { get; set; } = null;

        /// <summary>
        /// Indicates if the supplies list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Supplies == null || Supplies.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        /// <summary>
        /// Unselects currently selected supply item
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected supply item
            IoC.Stock.CurrentSupplyNumber = null;

        }
        #endregion

    }
}
