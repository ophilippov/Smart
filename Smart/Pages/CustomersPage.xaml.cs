using Smart.Core;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : BasePage<CustomersViewModel>
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomersPage() : base()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">A specific view model to use for this page</param>
        public CustomersPage(CustomersViewModel specificViewModel) : base(specificViewModel)
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
            if (CustomersList == null)
                return;

            //Fade in orders list
            var sb = new Storyboard();
            sb.AddFadeIn();
            sb.Begin(CustomersList);
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
