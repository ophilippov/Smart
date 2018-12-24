using Smart.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class AppPageHelpers
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="page">The page to create</param>
        /// <param name="viewModel">The specific view model for this page</param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            //Find the appropriate page
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);
                case ApplicationPage.ManagerOrders:
                    return new OrdersPage(viewModel as OrdersViewModel);
                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);
                case ApplicationPage.StockOrders:
                    return new StockOrdersPage(viewModel as StockOrdersViewModel);
                case ApplicationPage.StockProducts:
                    return new ProductsPage(viewModel as ProductsViewModel);
                case ApplicationPage.StockSupplies:
                    return new SuppliesPage(viewModel as SuppliesViewModel);
                case ApplicationPage.StockWriteOffs:
                    return new WriteOffsPage(viewModel as WriteOffsViewModel);
                case ApplicationPage.Discounts:
                    return new DiscountsPage(viewModel as DiscountsViewModel);
                case ApplicationPage.Customers:
                    return new CustomersPage(viewModel as CustomersViewModel);
                case ApplicationPage.Suppliers:
                    return new SuppliersPage(viewModel as SuppliersViewModel);
                case ApplicationPage.ManagerSearch:
                    //TODO: add a view model
                    return new OrdersSearchPage();
                default:
                    return null; 
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationMainPage(this BasePage page)
        {
            //Find the application page that matches the base page
            if (page is LoginPage)
                return ApplicationPage.Login;
            else if (page is OrdersPage)
                return ApplicationPage.ManagerOrders;
            else if (page is RegisterPage)
                return ApplicationPage.Register;
            else if (page is StockOrdersPage)
                return ApplicationPage.StockOrders;
            else if (page is OrdersSearchPage)
                return ApplicationPage.ManagerSearch;
            else if (page is ProductsPage)
                return ApplicationPage.StockProducts;
            else if (page is SuppliesPage)
                return ApplicationPage.StockSupplies;
            else if (page is WriteOffsPage)
                return ApplicationPage.StockWriteOffs;
            else if (page is DiscountsPage)
                return ApplicationPage.Discounts;
            else if (page is CustomersPage)
                return ApplicationPage.Customers;
            else if (page is SuppliersPage)
                return ApplicationPage.Suppliers;


            return default(ApplicationPage);
            throw new ArgumentException("Cannot convert this page to the desired type");
        }

    }
}
