﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{

    /// <summary>
    /// A view model for a Manager orders page
    /// </summary>
    public class OrdersViewModel : BaseViewModel
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
        public OrdersViewModel()
        {
            //Initialize commands
            UnselectCommand = new RelayCommand(Unselect);
        }
        #endregion

        /// <summary>
        /// The order list items for the list
        /// </summary>
        public List<OrdersListItemViewModel> Orders { get; set; } = null;

        /// <summary>
        /// Indicates if the orders list have any content
        /// </summary>
        public bool HasContent
        {
            get
            {
                if (Orders == null || Orders.Count == 0)
                    return false;
                else
                    return true;
            }
            private set => HasContent = value;
        }

        #region Commands helpers

        private void Unselect()
        {
            //Unselect currently selected order item
            IoC.Manager.CurrentOrderNumber = null;

        }
        #endregion

    }
}
