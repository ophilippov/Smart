

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// Helpers to animate pages in specific ways 
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Zooms in and fades in page from the center
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task ZoomAndFadeInCenter(this Page page, float duration)
        {
           

            //Create the storyboard
            var sb = new Storyboard();

            //Add zoom in from center animation
            sb.AddZoomInCenter(page, duration);

            //Add fade in animation
            sb.AddFadeIn(duration);

            //Start this storyboard
            sb.Begin(page);

            //Make this page visible
            page.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));
        
        }


        /// <summary>
        /// Zooms out and fades out page to the center
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task ZoomAndFadeOutCenter(this Page page, float duration)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add zoom out from center animation
            sb.AddZoomOutCenter(page, duration);

            //Add fade out animation
            sb.AddFadeOut(duration);

            //Start this storyboard
            
            sb.Begin(page);

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }



        /// <summary>
        /// Slides and fades out <see cref="Page"/> to the left
        /// </summary>
        /// <param name="element">The <see cref="Page"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutLeft(this Page page, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add slid in from the left
            sb.AddSlideToLeft(page.WindowWidth, duration);

            //Add fade out animation
            sb.AddFadeOut(duration);

            //Start this storyboard
            sb.Begin(page);

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

            //Make this element invisible
            page.Visibility = Visibility.Hidden;


        }


        /// <summary>
        /// Slides and fades in <see cref="Page"/> from the left
        /// </summary>
        /// <param name="element">The <see cref="Page"/> to animate</param>
        /// <param name="duration">The duration of this animation</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInLeft(this Page page, float duration = 0.5f)
        {


            //Create the storyboard
            var sb = new Storyboard();

            //Add slid in from the left
            sb.AddSlideFromLeft(page.WindowWidth, duration);

            //Add fade out animation
            sb.AddFadeIn(duration);

            //Start this storyboard
            sb.Begin(page);

            //Make this element visible
            page.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(duration * 1000));

        }

    }
}
