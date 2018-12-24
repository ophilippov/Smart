using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// A main page of the application
    /// </summary>
    public enum ApplicationPage
    {
        //Main pages
        None = 0,        
        Login = 1,
        Register = 2,
        ManagerOrders = 3,
        StockProducts = 4,
        StockSupplies = 5,       
        StockWriteOffs = 6,
        StockOrders = 7,
        Discounts = 8,
        Customers = 9, 
        Suppliers = 10,
        Payments = 11, 
        Reports = 12, 
        Settings = 13,

        //Additional pages
        ManagerSearch = 14,
        StockProductsSearch = 15,
        StockSuppliesSearch = 16,
        StockWriteOffsSearch = 17,
        StockOrdersSearch = 18,
        DiscountsSearch = 19,
        CustomersSearch = 20,
        SuppliersSearch = 21,
        PaymentsSearch = 22,
        ReportsSearch = 23
    }

    
}
