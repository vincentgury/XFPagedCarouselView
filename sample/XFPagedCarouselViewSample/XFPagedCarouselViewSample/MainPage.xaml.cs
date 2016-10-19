using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XFPagedCarouselView;

namespace XFPagedCarouselViewSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.PagedCarouselView.ItemsSource = new List<PageableItem>
            {
                new PageableItem
                {
                    Title = "Hello World! This page contains a PagedCarouselView. Default pager shape is a circle",
                    BackgroundColor = Color.Red,
                },
                new PageableItem
                {
                    Title = "Page indicators respond to touch. Try touching them!",
                    BackgroundColor = Color.FromRgb(255, 165, 0),
                    CustomSelectedColor = Color.FromRgba(255, 0, 0, 150)
                },
                new PageableItem
                {
                    Title = "This item has a custom size... Look how big is the circle :o",
                    BackgroundColor = Color.Green,
                    CustomSize = new Size(30, 30)
                },
                new PageableItem
                {
                    Title = "This item has a custom style! Don't you see the square?",
                    BackgroundColor = Color.Teal,
                    CustomPagerStyle = PagerStyle.Square
                },
                new PageableItem
                {
                    Title = "Of course, you can customize multiple properties at the same time...",
                    BackgroundColor = Color.Silver,
                    CustomPagerStyle = PagerStyle.Heart,
                    CustomSize = new Size(30, 30),
                    CustomSelectedColor = Color.Red,
                    CustomUnselectedColor = Color.FromRgba(255, 100, 100, 150)
                },
                new PageableItem
                {
                    Title = "Other properties can be customized for each page, have a look at BasePageableItem class to see more..."
                            + Environment.NewLine + Environment.NewLine
                            + "You can also customize the whole PagedCarouselView (Show/Hide pager, pager margin, ...)",
                    BackgroundColor = Color.Purple,
                }
            };
        }
    }
}
