
namespace Smart
{
    /// <summary>
    /// Styles of page animations for appearing/disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation takes place
        /// </summary>
        None = 0, 
        /// <summary>
        /// The page zooms in and fades in from center of the screen
        /// </summary>
        ZoomAndFadeInCenter = 1,
        /// <summary>
        /// The page zooms out and fades out to center of the screen
        /// </summary>
        ZoomAndFadeOutCenter = 2,

        /// <summary>
        /// The page slides in and fades in from the left of the screen
        /// </summary>
        SlideAndFadeInLeft = 3,
        
        /// <summary>
        /// The page slides out and fades out to the left of the screen
        /// </summary>
        SlideAndFadeOutLeft = 4,

        /// <summary>
        /// The page slides in and fades in from the right of the screen
        /// </summary>
        SlideAndFadeInRight = 5,

        /// <summary>
        /// The page slides out and fades out to the right of the screen
        /// </summary>
        SlideAndFadeOutRight = 6,

        /// <summary>
        /// The page slides in and fades in from the top of the screen
        /// </summary>
        SlideAndFadeInTop = 7,

        /// <summary>
        /// The page slides out and fades out to the top of the screen
        /// </summary>
        SlideAndFadeOutTop = 8,

        /// <summary>
        /// The page slides in and fades in from the bottom of the screen
        /// </summary>
        SlideAndFadeInBottom = 9,

        /// <summary>
        /// The page slides out and fades out to the bottom of the screen
        /// </summary>
        SlideAndFadeOutBottom = 10,

        /// <summary>
        /// The page fades in
        /// </summary>
        FadeIn = 11,

        /// <summary>
        /// The page fades out 
        /// </summary>
        FadeOut = 12
    }
       
    
}
