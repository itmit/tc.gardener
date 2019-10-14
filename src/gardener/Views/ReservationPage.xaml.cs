using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        private ReservationViewModel _viewModel;
        public ReservationPage(Place place)
        {
            InitializeComponent();
            _viewModel = new ReservationViewModel(Navigation, place, OnFormSend);
            BindingContext = _viewModel;
        }
        private void OnFormSend(bool isSuccess)
        {
            if (isSuccess)
            {
                DisplayAlert(Properties.Strings.Attention, Properties.Strings.Theformwassuccessfullysent, Properties.Strings.Ok);
            }
            else
            {
                DisplayAlert(Properties.Strings.Attention, Properties.Strings.Name + ',' + Properties.Strings.LastName + ',' + Properties.Strings.Number + ' ' + Properties.Strings.Notreading, Properties.Strings.Ok);
            }
        }
    }
}