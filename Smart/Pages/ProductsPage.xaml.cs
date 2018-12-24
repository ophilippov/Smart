using Smart.Core;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : BasePage<ProductsViewModel>
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductsPage() : base()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">A specific view model to use for this page</param>
        public ProductsPage(ProductsViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
            Setup();

        }

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()    
        {
            //Make sure UI exists first
            if (ProductsList == null)
                return;

            //Fade in orders list
            var sb = new Storyboard();
            sb.AddFadeIn();
            sb.Begin(ProductsList);
        }


        /// <summary>
        /// Sets up this page
        /// </summary>
        private void Setup()
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInRight;
            PageUnloadAnimation = PageAnimation.FadeOut;
            UnloadAnimationDuration = 0.3f;

        }
    }
}
