using gardener.Views.ListView;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        public void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage());

            //  var newBounds = new Rectangle(MapGardener.Bounds.X - 10, MapGardener.Bounds.Y - 5,
            //      MapGardener.Bounds.Width + 20, MapGardener.Bounds.Height + 10);
            //  MapGardener.LayoutTo(newBounds, 1500, Easing.CubicInOut);
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
           Navigation.PushAsync(new ListSalePage());
        }
    }
}