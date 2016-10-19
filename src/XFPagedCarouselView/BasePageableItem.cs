using Xamarin.Forms;

namespace XFPagedCarouselView
{
    /// <summary>
    /// BasePageableItem holds few properties allowing you to customize the pager on each different page
    /// The items you set to PagedCarouselView.ItemsSource must inherit from BasePageableItem
    /// </summary>
    public abstract class BasePageableItem
    {
        /// <summary>
        /// Allows you to set a custom size on the current page indicator - ignored if null - default value is null
        /// </summary>
        public Size? CustomSize { get; set; }
        /// <summary>
        /// Allows you to set a custom color when the current page indicator is selected - ignored if null - default value is null
        /// </summary>
        public Color? CustomSelectedColor { get; set; }
        /// <summary>
        /// Allows you to set a custom color when the current page indicator is unselected - ignored if null - default value is null
        /// </summary>
        public Color? CustomUnselectedColor { get; set; }
        /// <summary>
        /// Allows you to set a custom page indicator style on the current page indicator - ignored if null - default value is null
        /// </summary>
        public PagerStyle? CustomPagerStyle { get; set; }
    }
}