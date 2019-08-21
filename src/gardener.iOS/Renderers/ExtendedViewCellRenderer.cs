using System;
using gardener;
using gardener.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(ExtendedViewCellRenderer))]
namespace gardener.iOS.Renderers
{
    internal class ExtendedViewCellRenderer : ViewCellRenderer
    {
    }
}
