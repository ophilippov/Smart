using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Stock write-off's page
    /// </summary>
    public class WriteOffsViewModel : BaseViewModel
    {
        #region Public Commands

        /// <summary>
        /// A command to unselect any write-off
        /// </summary>
        public ICommand UnselectCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Public constructor
        /// </summary>
        public WriteOffsViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The supplies list items for the list
        /// </summary>
        public List<WriteOffsListItemViewModel> WriteOffs { get; set; } = null;

        /// <summary>
        /// Indicates if the write-offs list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (WriteOffs == null || WriteOffs.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        /// <summary>
        /// Unselects currently selected write-off
        /// </summary>
        private void Unselect()
        {
            //Unselect currently selected write-off item
            IoC.Stock.CurrentWriteOffNumber = null;

        }
        #endregion
    }
}
