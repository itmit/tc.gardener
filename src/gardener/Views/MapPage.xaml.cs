using gardener.Views.ListView;
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

        private void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage());
        }

        private void ImageButton_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage());
        }
    }
}