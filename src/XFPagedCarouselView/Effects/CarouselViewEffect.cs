using Xamarin.Forms;
#pragma warning disable 1591

namespace XFPagedCarouselView.Effects
{
    public class CarouselViewEffect : RoutingEffect
    {
        public bool Bounces { get; set; } = true;
        public bool ShowsHorizontalScrollIndicator { get; set; } = true;
        public bool ShowsVerticalScrollIndicator { get; set; } = true;

        public CarouselViewEffect() : base("XFPagedCarouselView.CollectionViewEffect")
        {
        }
    }
}