using Smart.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для ManagerSearchPage.xaml
    /// </summary>
    public partial class OrdersSearchPage : BasePage<OrdersSearchViewModel>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public OrdersSearchPage()
        {
            InitializeComponent();

            Setup();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">A specific view model for this page</param>
        public OrdersSearchPage(OrdersSearchViewModel specificViewModel):base(specificViewModel)
        {
            InitializeComponent();

            Setup();
        }

        /// <summary>
        /// Setups this page
        /// </summary>
        private void Setup()
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInRight;
            PageUnloadAnimation = PageAnimation.SlideAndFadeOutRight;
            keepMargin = false;
        }
        
        

        
    }
}
