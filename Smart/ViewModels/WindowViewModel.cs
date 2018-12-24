

using Smart.Core;
using System.Windows;
using System.Windows.Input;

namespace Smart
{
    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 15;
        #endregion

        #region Public properties



        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 1150;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 690;


        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return (mWindow.WindowState == WindowState.Maximized) ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }


        /// <summary>
        /// The padding of the inner content of the window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(0); } }


        

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The height of the title bar / caption of the window 
        /// </summary>
        public int TitleHeight { get; set;} = 21;

        /// <summary>
        /// The height of the title bar / caption of the window 
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// The height of the status bar of the window
        /// </summary>
        public int StatusHeight { get; set; } = 26;

        /// <summary>
        /// The height of the status bar of the window
        /// </summary>
        public GridLength StatusHeightGridLenght { get { return new GridLength(StatusHeight); } }

        /// <summary>
        /// True if we sould have a dimmend overlay on the window
        /// such as when a popup is visible or the window is not focused
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }
      
        
        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion


        #region Constructors
        /// <summary>
        /// The default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
            
            //Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                //Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));

            };

            // Create commands 
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix windows resize issue
            var resizer = new WindowResizer(mWindow);
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
