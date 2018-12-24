

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Smart
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
   public static class StoryboardHelpers
    {

        /// <summary>
        /// Adds a zoom in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">Duration of this animation</param>
        /// <param name="decelerationRatio">Deceleration ration of this animation</param>
        public static void AddZoomInCenter (this Storyboard storyboard, UIElement uiElement, float duration = 0.5f, float decelerationRatio = 0.9f)
        {
            //Create the Transform group to have an ability to scaling this page in
            var tGroup = new TransformGroup();
            var tScale = new ScaleTransform(1, 1);
            tGroup.Children.Add(tScale);
            uiElement.RenderTransformOrigin = new Point(0.5, 0.5);
            uiElement.RenderTransform = tGroup;

            //Create the ScaleX render transform animation
            var xAnimation = new DoubleAnimation
            {
                To = 1.0d,
                From = 0.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio
            };

            //Create the ScaleY render transform animation
            var yAnimation = new DoubleAnimation
            {
                To = 1.0d,
                From = 0.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio
            };

            //Set target property names
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("RenderTransform.Children[0].ScaleX"));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("RenderTransform.Children[0].ScaleY"));

            //It doesn`t work for some reasons
            //Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(RenderTransform).(ScaleTransform.ScaleX)"));
            //Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(RenderTransform).(ScaleTransform.ScaleY)"));
            //Add these to storyboard
            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

        }

        /// <summary>
        /// Adds a zoom in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">Duration of this animation</param>
        /// <param name="accelerationRatio">Acceleration ratio of this animation</param>
        public static void AddZoomOutCenter(this Storyboard storyboard, UIElement uiElement, float duration = 0.5f, float accelerationRatio = 0.1f)
        {
            //Create the Transform group to have an ability to scaling this page out
            var tGroup = new TransformGroup();
            var tScale = new ScaleTransform(1, 1);
            tGroup.Children.Add(tScale);
            
            uiElement.RenderTransform = tGroup;

            //Create the ScaleX render transform animation
            var xAnimation = new DoubleAnimation
            {
                To = 0.0d,
                From = 1.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio
            };

            //Create the ScaleY render transform animation
            var yAnimation = new DoubleAnimation
            {
                To = 0.0d,
                From = 1.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio
            };

            //Set target property names
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("RenderTransform.Children[0].ScaleX"));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("RenderTransform.Children[0].ScaleY"));

            //Add these to storyboard
            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

        }



        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">Duration of this animation</param>
        public static void AddFadeIn(this Storyboard storyboard, float duration = 0.5f)
        {
            
            //Create the ScaleX render transform animation
            var animation = new DoubleAnimation
            {
                To = 1.0d,
                From = 0.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration))
            };

           

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            //Add these to storyboard
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">Duration of this animation</param>
        public static void AddFadeOut(this Storyboard storyboard, float duration = 0.5f)
        {

            //Create the ScaleX render transform animation
            var animation = new DoubleAnimation
            {
                To = 0.0d,
                From = 1.0d,
                Duration = new Duration(TimeSpan.FromSeconds(duration))
            };



            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            //Add these to storyboard
            storyboard.Children.Add(animation);

        }

        /// <summary>
        /// Add a slide animation from the left for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the left to start from</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="decelerationRatio">Deceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>

        public static void AddSlideFromLeft (this Storyboard storyboard, double offset, float duration = 0.5f, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide animation to the left for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the left to end at</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="accelerationRatio">Acceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>

        public static void AddSlideToLeft(this Storyboard storyboard, double offset, float duration = 0.5f, float accelerationRatio = 0.1f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio,
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                From = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide animation from the right for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="decelerationRatio">Deceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>

        public static void AddSlideFromRight(this Storyboard storyboard, double offset, float duration = 0.5f, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                From = new Thickness(keepMargin ? offset: 0, 0,-offset, 0),
                To = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add a slide animation to the right for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the right to end at</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="accelerationRatio">Acceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>

        public static void AddSlideToRight(this Storyboard storyboard, double offset, float duration = 0.5f, float accelerationRatio = 0.1f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio,
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                From = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }



        /// <summary>
        /// Add a slide animation from the top for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the top to start from</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="decelerationRatio">Deceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same height during animation</param>

        public static void AddSlideFromTop(this Storyboard storyboard, double offset, float duration = 0.5f, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide animation to the top for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the top to end at</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="accelerationRatio">Acceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same height during animation</param>

        public static void AddSlideToTop(this Storyboard storyboard, double offset, float duration = 0.5f, float accelerationRatio = 0.1f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio,
                To = new Thickness(0, -offset, 0 , keepMargin ? offset : 0),
                From = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide animation from the bottom for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the bottom to start from</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="decelerationRatio">Deceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same height during animation</param>

        public static void AddSlideFromBottom(this Storyboard storyboard, double offset, float duration = 0.5f, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                From = new Thickness(0, keepMargin ? offset : 0, 0 , -offset),
                To = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add a slide animation to the bottom for the target storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation to</param>
        /// <param name="offset">The distance to the bottom to end at</param>
        /// <param name="duration">Duration of the animation in seconds</param>
        /// <param name="accelerationRatio">Acceleration ratio for this animation</param>
        /// <param name="keepMargin"> Whether to keep the element at the same height during animation</param>

        public static void AddSlideToBottom(this Storyboard storyboard, double offset, float duration = 0.5f, float accelerationRatio = 0.1f, bool keepMargin = true)
        {
            //Create a new thickness animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                AccelerationRatio = accelerationRatio,
                To = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                From = new Thickness(0)

            };

            //Set target property names
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //Add this to storyboard
            storyboard.Children.Add(animation);
        }

    }
}
