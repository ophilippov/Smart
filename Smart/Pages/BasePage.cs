
using Smart.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// The base page for all pages to gain base functionality 
    /// </summary>
    public class BasePage : UserControl
    {

        #region Private members

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        private object mViewModel;
        #endregion

        #region Public Properties
        /// <summary>
        /// The animation to play when the page is first loaded 
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.ZoomAndFadeInCenter;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutLeft;


        /// <summary>
        /// The duration of page animation on unload
        /// </summary>
        public float UnloadAnimationDuration { get; set; } = 0.5f;

        /// <summary>
        /// The duration of page animation on load
        /// </summary>
        public float LoadAnimationDuration { get; set; } = 0.5f;

        /// <summary>
        /// A flag to indicate if this page should animate out on load.
        /// Useful for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOutOnLoad { get; set; }

        /// <summary>
        ///  Indicates whether to keep the element at the same width during animation
        /// </summary>
        public bool keepMargin { get; set; } = true;
        
        /// <summary>
        /// The view model, associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get => mViewModel; 
            set
            {
                //If nothing has changed, return
                if (mViewModel == value) return;

                //Update the value
                mViewModel = value;

                //Fire the view model changed method
                OnViewModelChanged();

                //Set the data context for this page
                this.DataContext = mViewModel;
            }
        }
        #endregion


        #region Public Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {

            //If we animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //Listening out for the page loading
            this.Loaded += BasePage_Loaded;

           

        }




        #endregion

        #region Animation Load/Unload

      

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //If we are setup to animate out on load
            if (ShouldAnimateOutOnLoad)
                //Animate out the page 
                await AnimateOut();
            //Otherwise...
            else
                //Animate the page in
                await AnimateIn();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            //Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.ZoomAndFadeInCenter:
                    await this.ZoomAndFadeInAsync(false, LoadAnimationDuration);
                    break;
                case PageAnimation.SlideAndFadeInLeft:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Left, false, LoadAnimationDuration, size: (int)Application.Current.MainWindow.ActualWidth, keepMargin: keepMargin);
                    break;
                case PageAnimation.SlideAndFadeInRight:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Right, false, LoadAnimationDuration, size: (int)Application.Current.MainWindow.ActualWidth, keepMargin: keepMargin);
                    break;
                case PageAnimation.SlideAndFadeInTop:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Top, false, LoadAnimationDuration, size: (int)Application.Current.MainWindow.ActualHeight, keepMargin: keepMargin);
                    break;
                case PageAnimation.SlideAndFadeInBottom:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Bottom, false, LoadAnimationDuration, size: (int)Application.Current.MainWindow.ActualHeight, keepMargin: keepMargin);
                    break;
                case PageAnimation.FadeIn:
                    await this.FadeInAsync(false, LoadAnimationDuration);
                    break;
                default: break;
            }


        }

        /// <summary>
        /// Animates this page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            //Make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.ZoomAndFadeOutCenter:
                    await this.ZoomAndFadeOutAsync(UnloadAnimationDuration);
                    break;
                case PageAnimation.SlideAndFadeOutLeft:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Left, UnloadAnimationDuration, size: (int)Application.Current.MainWindow.ActualWidth, keepMargin:keepMargin);
                    break;
                case PageAnimation.SlideAndFadeOutRight:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Right, UnloadAnimationDuration, size: (int)Application.Current.MainWindow.ActualWidth, keepMargin: keepMargin);
                    break;
                case PageAnimation.SlideAndFadeOutTop:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Top, UnloadAnimationDuration, size: (int)Application.Current.MainWindow.ActualHeight, keepMargin: keepMargin);
                    break;
                case PageAnimation.SlideAndFadeOutBottom:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Bottom, UnloadAnimationDuration, size: (int)Application.Current.MainWindow.ActualHeight, keepMargin: keepMargin);
                    break;
                case PageAnimation.FadeOut:
                    await this.FadeOutAsync(UnloadAnimationDuration);
                    break;
                default: break;
            }
        }
        #endregion


        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged() { }
        
    }

    /// <summary>
    /// A base page with added ViewModel support 
    /// 
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {


        #region Public Properties

        /// <summary>
        /// A view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }
        #endregion


        #region Public Constructors

        /// <summary>
        /// Default constructor
        /// </summary>

        public BasePage() : base()
        {

            //Create a default view model
            this.ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use, if any</param>
        public BasePage(VM specificViewModel = null) : base()
        {
            //Set specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                //Create a default view model
                this.ViewModel = IoC.Get<VM>();
        }


        #endregion

    }
}
