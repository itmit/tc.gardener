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

        private void OpenMap(object sender, System.EventArgs e)
        {
            DisplayAlert("Схема карты", "Тут карта", "Ок");
        }
    }
}