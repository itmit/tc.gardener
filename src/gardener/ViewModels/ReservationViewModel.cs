using System.Windows.Input;
using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ReservationViewModel : BaseViewModel
	{
		private INavigation _navigation;

		public Place Place { get; }

		private string _lastName;
		private string _firstName;
		private string _phoneNumber;

		public ReservationViewModel(INavigation navigation, Place place)
		{
			_navigation = navigation;
			Place = place;

			ReservationCommand = new RelayCommand(obj =>
			{
				ReservationCommandExecute();
			}, obj => CrossConnectivity.Current.IsConnected);
		}

		public void ReservationCommandExecute()
		{
			var service = new PlaceDataStore();

			service.ReservationPlace(new Reservation
			{
				PhoneNumber = PhoneNumber,
				Place = Place,
				FirstName = FirstName,
				LastName = LastName
			});
		}

		public string LastName
		{
			get => _lastName;
			set => SetProperty(ref _lastName, value);
		}

		public string FirstName
		{
			get => _firstName;
			set => SetProperty(ref _firstName, value);
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

		public ICommand ReservationCommand
		{
			get;
		}

		protected override void OnLanguageChanged()
		{ }
	}
}
