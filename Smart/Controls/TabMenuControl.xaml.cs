
using Smart.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;


namespace Smart
{
    /// <summary>
    /// TabMenu control
    /// </summary>
    public partial class TabMenuControl : UserControl
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public TabMenuControl()
        {
            InitializeComponent();

            Tabs.SelectionChanged += Tabs_SelectionChanged;

        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Fires when current menu tab item is changed
        /// </summary>
        /// <param name="sender">Current tab control</param>
        /// <param name="e"></param>
        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If the user has not logged in yet
            if (!IoC.Application.IsLoggedIn) return;

            //Get currently selected tab item
            var currentItem = (TabItem)((sender as TabControl).SelectedItem);

            switch (currentItem.Name)
            {
                case "Orders":
                    AppConfigure.OrdersConfigure();
                    break;
                case "Stock":
                    AppConfigure.StockConfigure();
                    break;

                case "Discounts":
                    AppConfigure.DiscountsConfigure();
                    break;

                case "Customers":
                    AppConfigure.CustomersConfigure();
                    break;

                case "Suppliers":
                    AppConfigure.SuppliersConfigure();
                    break;
                //TODO: complete this switch

                default:
                    //TODO: remove this
                    IoC.Application.GoToPageMain(ApplicationPage.None);
                    break;
            }
        }

        #endregion


    }
}
