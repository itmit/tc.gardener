using gardener.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace gardener.ViewModels
{
    public class PlaceViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        public PlaceViewModel(INavigation navigation)
        {
            _navigation = navigation;

            
                 _navigation.PushAsync(new ReservationPage());
           
        }

        public ICommand Resevation
        {
            get;
        }

        public INavigation Navigation => _navigation;

        protected override void OnLanguageChanged()
        {
        }
    }
}
