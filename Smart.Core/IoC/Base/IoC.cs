using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {


        #region Public properties
        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="IUIManager"/> instance, binded to the IoC Kernel
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the <see cref="ApplicationViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="AppManagerViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static AppManagerViewModel Manager => IoC.Get<AppManagerViewModel>();


        /// <summary>
        /// A shortcut to access the <see cref="AppStockViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static AppStockViewModel Stock => IoC.Get<AppStockViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="AppDiscountsViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static AppDiscountsViewModel Discounts => IoC.Get<AppDiscountsViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="AppCustomersViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static AppCustomersViewModel Customers => IoC.Get<AppCustomersViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="AppSuppliersViewModel"/> instance, binded to the IoC Kernel
        /// </summary>
        public static AppSuppliersViewModel Suppliers => IoC.Get<AppSuppliersViewModel>();

        /// <summary>
        /// A shortcut to access the <see cref="ILogFactory"/> instance, binded to the IoC Kernel
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();
        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up 
        ///       to ensure all services can be found
        /// </summary>
        public static void Setup()
        {
            //Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            //Bind to a single instance of Application view model 
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            //Bind to a single instance of Manager view model 
            Kernel.Bind<AppManagerViewModel>().ToConstant(new AppManagerViewModel());

            //Bind to a single instance of Stock view model 
            Kernel.Bind<AppStockViewModel>().ToConstant(new AppStockViewModel());
            
            //Bind to a single instance of Discounts view model 
            Kernel.Bind<AppDiscountsViewModel>().ToConstant(new AppDiscountsViewModel());

            //Bind to a single instance of Customers view model 
            Kernel.Bind<AppCustomersViewModel>().ToConstant(new AppCustomersViewModel());

            //Bind to a single instance of Suppliers view model 
            Kernel.Bind<AppSuppliersViewModel>().ToConstant(new AppSuppliersViewModel());

        }
        #endregion

        /// <summary>
        /// Gets a service from the IoC of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
