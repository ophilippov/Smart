using Smart.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Логика взаимодействия для PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {

        #region Dependency properties
        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Register a <see cref="CurrentPage"/> as a <see cref="DependencyProperty"/>
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));



        /// <summary>
        /// The specific view model for the current 
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// Register a <see cref="CurrentPage"/> as a <see cref="DependencyProperty"/>
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(PageHost), new UIPropertyMetadata());
        #endregion

        

        #region Property Changed Events
        /// <summary>
        /// Called when <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            //Get current values
            var currentPage = (ApplicationPage)value;
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //Get the frames
            var oldPageFrame = (d as PageHost).OldPage;
            var newPageFrame = (d as PageHost).NewPage;

            //If the current page hasn't changed
            //just update the view model
            if(newPageFrame.Content is BasePage page &&
                page.ToApplicationMainPage() == currentPage)
            {
                //Just update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            //Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove current page from the new page frame
            newPageFrame.Content = null;

            //Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            //Animate out previous page when the Loaded event fires
            //right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                //Tell old page to animate out
                oldPage.ShouldAnimateOutOnLoad = true;

                //Once it is done, remove it
                //Task.Delay go to the non-UI thread
                
                Task.Delay((int)(oldPage.UnloadAnimationDuration * 1000)).ContinueWith((t) =>
                {
                    //And then we return into the UI-thread
                    //And remove old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                   
                });
            }
            
            //Set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        } 

        #endregion



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //If we are in a Designer Mode
           if (DesignerProperties.GetIsInDesignMode(this))
           {
                NewPage.Content = IoC.Application.CurrentMainPage.ToBasePage();
                //OldPage.Content = null;
           }
        }     
        #endregion
    }
}
