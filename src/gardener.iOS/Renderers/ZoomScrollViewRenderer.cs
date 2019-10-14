using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;
using gardener.iOS.Renderers;
using gardener.Controls;

[assembly: ExportRenderer(typeof(ZoomScroll), typeof(ZoomScrollViewRenderer))]
namespace gardener.iOS.Renderers
{
    public class ZoomScrollViewRenderer : ScrollViewRenderer
    {
        // bool zoomEnabled = false;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            MaximumZoomScale = 3f;
            MinimumZoomScale = 1.0f;

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (Subviews.Length > 0)
            {
                ViewForZoomingInScrollView += GetViewForZooming;
            }
            else
            {
                ViewForZoomingInScrollView -= GetViewForZooming;
            }

        }

        public UIView GetViewForZooming(UIScrollView sv)
        {
            return Subviews.FirstOrDefault();
        }
    }
}