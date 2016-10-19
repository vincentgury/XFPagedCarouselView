using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFPagedCarouselView.Droid;
using XFPagedCarouselView.Effects;

[assembly: ResolutionGroupName("XFPagedCarouselView")]
[assembly: ExportEffect(typeof(CollectionViewEffect), "CollectionViewEffect")]
namespace XFPagedCarouselView.Droid
{
    public class CollectionViewEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var view = this.Control as RecyclerView;

            if (view != null)
            {
                var effect = (CarouselViewEffect)this.Element.Effects.FirstOrDefault(e => e is CarouselViewEffect);

                if (effect != null)
                {
                    view.OverScrollMode = effect.Bounces ? OverScrollMode.Always : OverScrollMode.Never;
                    view.HorizontalScrollBarEnabled = effect.ShowsHorizontalScrollIndicator;
                    view.VerticalScrollBarEnabled = effect.ShowsVerticalScrollIndicator;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
