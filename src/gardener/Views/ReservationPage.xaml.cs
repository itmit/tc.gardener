using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
		public ReservationPage(Place place)
        {
			InitializeComponent();
            BindingContext = new ReservationViewModel(Navigation, place);
        }
    }
}