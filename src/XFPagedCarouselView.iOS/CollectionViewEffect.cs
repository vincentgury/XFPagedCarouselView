using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFPagedCarouselView.Effects;
using XFPagedCarouselView.iOS;

[assembly: ResolutionGroupName("XFPagedCarouselView")]
[assembly: ExportEffect(typeof(CollectionViewEffect), "CollectionViewEffect")]
namespace XFPagedCarouselView.iOS
{
    public class CollectionViewEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var view = this.Control as UICollectionView;

            if (view != null)
            {
                var effect = (CarouselViewEffect)this.Element.Effects.FirstOrDefault(e => e is CarouselViewEffect);

                if (effect != null)
                {
                    view.Bounces = effect.Bounces;
                    view.ShowsHorizontalScrollIndicator = effect.ShowsHorizontalScrollIndicator;
                    view.ShowsVerticalScrollIndicator = effect.ShowsVerticalScrollIndicator;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
