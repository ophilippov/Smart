using Smart.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in XAML files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties
        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        #endregion


        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        /// <summary>
        /// The Manager view model
        /// </summary>
        public static AppManagerViewModel ManagerViewModel => IoC.Manager;

        /// <summary>
        /// The Stock view model
        /// </summary>
        public static AppStockViewModel StockViewModel => IoC.Stock;
        
        /// <summary>
        /// The Discounts view model
        /// </summary>
        public static AppDiscountsViewModel DiscountsViewModel => IoC.Discounts;

        /// <summary>
        /// The Customers view model
        /// </summary>
        public static AppCustomersViewModel CustomersViewModel => IoC.Customers;

        /// <summary>
        /// The Suppliers view model
        /// </summary>
        public static AppSuppliersViewModel SuppliersViewModel => IoC.Suppliers;
    }
}
