using System.Collections.Generic;
using Xamarin.Forms;
using XFPagedCarouselView.Effects;

namespace XFPagedCarouselView
{
    /// <summary>
    /// A carousel view with extra paging features
    /// </summary>
    public partial class PagedCarouselView : ContentView
    {
#pragma warning disable 1591
        public static readonly BindableProperty IsPagedProperty = BindableProperty.Create(nameof(ShowPager), typeof (bool), typeof (PagedCarouselView), true, BindingMode.TwoWay);
#pragma warning restore 1591

        /// <summary>
        /// Show or hide the pager - default value is true
        /// </summary>
        public bool ShowPager
        {
            get { return (bool)this.GetValue(IsPagedProperty); }
            set { this.SetValue(IsPagedProperty, value); }
        }

        /// <summary>
        /// Allows you to set a custom size on all the page indicators - ignored if null - default value is null
        /// </summary>
        public Size? CustomSize
        {
            get { return this.CarouselViewPager.CustomSize; }
            set { this.CarouselViewPager.CustomSize = value; }
        }

        /// <summary>
        /// Allows you to set a custom page indicator style on all the page indicators - ignored if null - default value is null
        /// </summary>
        public PagerStyle PagerStyle
        {
            get { return this.CarouselViewPager.PagerStyle; }
            set { this.CarouselViewPager.PagerStyle = value; }
        }

        /// <summary>
        /// Gets or sets the pager margin - default value is (0, 0, 0, 10)
        /// </summary>
        public Thickness PagerMargin
        {
            get { return this.CarouselViewPager.Margin; }
            set { this.CarouselViewPager.Margin = value; }
        }

        /// <summary>
        /// Get or sets the items to build the page indicators - default value is null
        /// </summary>
        public IEnumerable<BasePageableItem> ItemsSource
        {
            get { return this.CarouselView.ItemsSource as IEnumerable<BasePageableItem>; }
            set { this.CarouselView.ItemsSource = value; }
        }

        /// <summary>
        /// Gets or sets the DataTemplate used to render each page of the carousel view - usage of DataTemplateSelector is allowed
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return this.CarouselView.ItemTemplate; }
            set
            {
                this.CarouselView.ItemTemplate = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PagedCarouselView()
        {
            this.InitializeComponent();
            
            this.CarouselView.Effects.Add(new CarouselViewEffect
            {
                Bounces = false,
                ShowsHorizontalScrollIndicator = false,
                ShowsVerticalScrollIndicator = false
            });

            AbsoluteLayout.SetLayoutBounds(this.CarouselView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(this.CarouselView, AbsoluteLayoutFlags.All);

            this.Content = this.MainLayout;
        }       
    }
}
