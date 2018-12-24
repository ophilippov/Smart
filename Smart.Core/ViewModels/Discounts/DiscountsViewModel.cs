using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Discounts page
    /// </summary>
    public class DiscountsViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// A command to unselect any discount
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public DiscountsViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The discounts list items for the list
        /// </summary>
        public List<DiscountsListItemViewModel> Discounts { get; set; } = null;

        /// <summary>
        /// Indicates if the discounts list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Discounts == null || Discounts.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        /// <summary>
        /// Unseletcs currently selected discount
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected discount item
            IoC.Discounts.CurrentDiscountNumber = null; 
            
        }
        #endregion

    }
}
