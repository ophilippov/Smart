using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Smart
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent>:BaseAttachedProperty<Parent, bool>
        where Parent: BaseAttachedProperty<Parent, bool>, new()  
    {

        #region Protected Properties

        /// <summary>
        /// A dictionary of all objects that is currently using this class
        /// </summary>
        protected Dictionary<DependencyObject, bool> mAlreadyLoaded = new Dictionary<DependencyObject, bool>();

        /// <summary>
        /// A dictionary of the FirstLoad values for each object that is currently using this class
        /// The most recent value used if we get a value changed before we do the first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mFirstLoadValue = new Dictionary<DependencyObject, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Get the FrameworkElement
            if (!(sender is FrameworkElement element))
                return;


            //Don`t fire if the value doesn`t changed
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoaded.ContainsKey(sender))
                return;

            

            //On first load...
            if (!mAlreadyLoaded.ContainsKey(sender))
            {
                // Flag that we are in first load but have not finished it
                mAlreadyLoaded[sender] = false;

                // Start off hidden before we decide how to animate
                // if we are to be animated out initially
                if (!(bool)value)
                    element.Visibility = Visibility.Hidden;

                //Create a single self-unhookable event
                //for the element`s Loaded event 

                RoutedEventHandler onLoaded = null;

                onLoaded = async (ss, ee) =>
                {
                    //Unhook ourselves
                    element.Loaded -= onLoaded;

                    //Slight delay after load is needed for some elements to get laid out
                    //and their widths/heights correctly calculated
                    await Task.Delay(5);

                    //Do desired animation
                    DoAnimation(element, mFirstLoadValue.ContainsKey(sender) ? mFirstLoadValue[sender] : (bool)value, true);

                    // Flag that we have finished first load
                    mAlreadyLoaded[sender] = true;
                };

                //Hook into the Loaded event of the element     
                element.Loaded += onLoaded;
            }
            // If we have started a first load but not fired the animation yet, update the property
            else if (mAlreadyLoaded[sender] == false)
                mFirstLoadValue[sender] = (bool)value;
            //Do desired animation  
            else DoAnimation(element, (bool)value, false);
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="value">The new value</param>
        /// <param name="firstLoad">Indicates if we are in the first load</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }

    }

    /// <summary>
    /// Fades in an image when the target updates
    /// </summary>
    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Make sure we have an image
            if (!(sender is Image image))
                return;

            //If we want to animate in...
            if ((bool)value)
                image.TargetUpdated += Image_TargetUpdated;
            else
                image.TargetUpdated -= Image_TargetUpdated;
        }

        private async void Image_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            await (sender as Image).FadeInAsync(false);
        }
    }


    /// <summary>
    /// Animates a FrameworkElemnt sliding and fadeing it from the top on show
    /// and sliding and fading out to the top on hide
    /// </summary>
    public class AnimateSlideAndFadeInFromTopProperty : AnimateBaseProperty<AnimateSlideAndFadeInFromTopProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideDirection.Top, firstLoad, firstLoad ? 0 : 0.3f, false);
            }
            else
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideDirection.Top, firstLoad ? 0 : 0.3f, false);
        }
    }

    /// <summary>
    /// Animates a FrameworkElemnt sliding it from the top on show
    /// and sliding out to the top on hide
    /// </summary>
    public class AnimateSlideInFromTopProperty : AnimateBaseProperty<AnimateSlideInFromTopProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
            {
                //Animate in
                await element.SlideInAsync(AnimationSlideDirection.Top, firstLoad, firstLoad ? 0 : 0.3f, false);
            }
            else
                //Animate out
                await element.SlideOutAsync(AnimationSlideDirection.Top, firstLoad ? 0 : 0.3f, false);
        }
    }



    /// <summary>
    /// Animates a FrameworkElemnt to fade in on show
    /// and to fade out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
            {
                //Animate in
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            }
            else
                //Animate out
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);
        }
    }
}
