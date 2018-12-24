using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Stock products page
    /// </summary>
    public class ProductsViewModel : BaseViewModel
    {

        #region Public Commands

        /// <summary>
        /// A command to unselect any product
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public ProductsViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion


        /// <summary>
        /// The order list items for the list
        /// </summary>
        public List<ProductsListItemViewModel> Products { get; set; } = null;

        /// <summary>
        /// Indicates if the orders list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Products == null || Products.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }


        #region Commands helpers

        /// <summary>
        /// Unseletcs currently selected product
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected product item
            IoC.Stock.CurrentProductArtNumber = null;

        }
        #endregion

    }
}
