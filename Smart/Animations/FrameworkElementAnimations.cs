

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Smart
{


    /// <summary>
    /// Helpers to animate <see cref="FrameworkElement"/> in specific ways 
    /// </summary>
    public static class FrameworkElementAnimations
    {

        #region Slide and fade In/Out


       

        /// <summary>
        /// Slides and fades in <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <param name="size">The animation width/height to animate to. If not specified the element actual width/heght is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideDirection direction, bool firstLoad,  float duration = 0.3f, bool keepMargin = true, int size=0)
        {


            //Create the storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                //Add slide from left animation
                case AnimationSlideDirection.Left:
                    sb.AddSlideFromLeft(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from right animation
                case AnimationSlideDirection.Right:
                    sb.AddSlideFromRight(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from top animation
                case AnimationSlideDirection.Top:
                    sb.AddSlideFromTop(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from bottom animation
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideFromBottom(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

            }

            //Add fade out animation
            sb.AddFadeIn(duration);

            //Start this storyboard
            sb.Begin(element);

            // Make element visible only if we are animating or it is the first load
            if (duration != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }

        /// <summary>
        /// Slides and fades out <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        /// <param name="size">The animation width/height to animate to. If not specified the element actual width/heght is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideDirection direction, float duration = 0.3f, bool keepMargin = true, int size = 0)
        {


            //Create the storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                //Add slide to left animation
                case AnimationSlideDirection.Left:
                    sb.AddSlideToLeft(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to right animation
                case AnimationSlideDirection.Right:
                    sb.AddSlideToRight(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to top animation
                case AnimationSlideDirection.Top:
                    sb.AddSlideToTop(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to bottom animation
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideToBottom(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

            }

            //Add fade out animation
            sb.AddFadeOut(duration);

            //Start this storyboard
            sb.Begin(element);

            // Make element  visible only if we are animating 
            if (duration != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

            //Make element invisible
            element.Visibility = Visibility.Hidden;

        }

        #endregion

        #region Slide In/Out




        /// <summary>
        /// Slides and fades in <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <param name="size">The animation width/height to animate to. If not specified the element actual width/heght is used</param>
        /// <returns></returns>
        public static async Task SlideInAsync(this FrameworkElement element, AnimationSlideDirection direction, bool firstLoad, float duration = 0.3f, bool keepMargin = true, int size = 0)
        {


            //Create the storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                //Add slide from left animation
                case AnimationSlideDirection.Left:
                    sb.AddSlideFromLeft(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from right animation
                case AnimationSlideDirection.Right:
                    sb.AddSlideFromRight(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from top animation
                case AnimationSlideDirection.Top:
                    sb.AddSlideFromTop(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide from bottom animation
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideFromBottom(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

            }

            
            //Start this storyboard
            sb.Begin(element);

            // Make element visible only if we are animating or it is the first load
            if (duration != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }

        /// <summary>
        /// Slides and fades out <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="direction">The direction of the slide</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        /// <param name="size">The animation width/height to animate to. If not specified the element actual width/heght is used</param>
        /// <returns></returns>
        public static async Task SlideOutAsync(this FrameworkElement element, AnimationSlideDirection direction, float duration = 0.3f, bool keepMargin = true, int size = 0)
        {


            //Create the storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                //Add slide to left animation
                case AnimationSlideDirection.Left:
                    sb.AddSlideToLeft(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to right animation
                case AnimationSlideDirection.Right:
                    sb.AddSlideToRight(size == 0 ? element.ActualWidth : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to top animation
                case AnimationSlideDirection.Top:
                    sb.AddSlideToTop(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

                //Add slide to bottom animation
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideToBottom(size == 0 ? element.ActualHeight : size, keepMargin: keepMargin, duration: duration);
                    break;

            }

           
            //Start this storyboard
            sb.Begin(element);

            // Make element  visible only if we are animating 
            if (duration != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

            //Make element invisible
            element.Visibility = Visibility.Hidden;

        }

        #endregion


        #region Fade in/out

        /// <summary>
        /// Fades in <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, bool firstLoad, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add fade in animation
            sb.AddFadeIn(duration);

            //Start this storyboard
            sb.Begin(element);

            // Make element visible only if we are animating or it is the first load
            if (duration != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }


        /// <summary>
        /// Fades out <see cref="FrameworkElement"/> 
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add fade out animation
            sb.AddFadeOut(duration);

            //Start this storyboard
            sb.Begin(element);

            /// Make element  visible only if we are animating 
            if (duration != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

            //Make element invisible
            element.Visibility = Visibility.Hidden;

        }
        #endregion

        #region Zoom and fade in/out

        /// <summary>
        /// Zooms in and fades in <see cref="FrameworkElement"/> from the center
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <param name="firstLoad">Indicates if this is the first load</param>
        /// <returns></returns>
        public static async Task ZoomAndFadeInAsync(this FrameworkElement element, bool firstLoad, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add zoom in from center animation
            sb.AddZoomInCenter(element, duration);

            //Add fade in animation
            sb.AddFadeIn(duration);

            //Start this storyboard
            sb.Begin(element);

            // Make element visible only if we are animating or it is the first load
            if (duration != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }


        /// <summary>
        /// Zooms out and fades out <see cref="FrameworkElement"/> to the center
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task ZoomAndFadeOutAsync(this FrameworkElement element, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add zoom out from center animation
            sb.AddZoomOutCenter(element, duration);

            //Add fade out animation
            sb.AddFadeOut(duration);

            //Start this storyboard
            sb.Begin(element);

            // Make element  visible only if we are animating 
            if (duration != 0)
                element.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

            //Make element invisible
            element.Visibility = Visibility.Hidden;

        } 
        #endregion
    }
}
