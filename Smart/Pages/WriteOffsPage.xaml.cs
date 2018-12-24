using Smart.Core;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для WriteOffsPage.xaml
    /// </summary>
    public partial class WriteOffsPage : BasePage<WriteOffsViewModel>
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public WriteOffsPage() : base()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">A specific view model to use for this page</param>
        public WriteOffsPage(WriteOffsViewModel specificViewModel) : base(specificViewModel)
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
            if (WriteOffsList == null)
                return;

            //Fade in write-offs list
            var sb = new Storyboard();
            sb.AddFadeIn();
            sb.Begin(WriteOffsList);
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
