using Android.Content;
using gardener;
using gardener.Droid;
using gardener.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(CustomEntryRenderer))]

namespace gardener.Droid
{
	internal class CustomEntryRenderer : EntryRenderer
	{
		#region .ctor
		public CustomEntryRenderer(Context context)
			: base(context)
		{
		}
		#endregion

		#region Overrided
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			Control?.SetBackgroundColor(Color.Rgb(255, 236, 209));
		}
		#endregion
	}
}
