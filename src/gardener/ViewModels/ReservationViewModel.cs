using System;
using System.Collections.Generic;
using System.Windows.Input;
using gardener.Models;
using gardener.Services;
using gardener.Views;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
    /// <summary>
    /// Представляет ViewModel для <see cref="ReservationPage" />.
    /// </summary>
	public class ReservationViewModel : BaseViewModel
	{
		private INavigation _navigation;

		public Place Place { get; }

		private string _lastName;
		private string _firstName;
		private string _phoneNumber;
		private string _placeTitle;
		private string _nameTitle;
		private string _lastNameTitle;
		private string _numberTitle;
		private string _reservationTitle;
		private string _rowTitle;
		private bool _isEnabled = true;

		public ReservationViewModel(INavigation navigation, Place place)
		{
			_navigation = navigation;
			Place = place;
            PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			LastNameTitle = Properties.Strings.LastName;
			NumberTitle = Properties.Strings.Number;
			ReservationTitle = Properties.Strings.Reservation;
			RowTitle = Properties.Strings.Row;

            ReservationCommand = new RelayCommand(obj =>
			{
				ReservationCommandExecute();
			}, obj => CrossConnectivity.Current.IsConnected);

        }

		public bool IsEnabled
		{
			get => _isEnabled;
			set => SetProperty(ref _isEnabled, value);
		}

		public string ReservationTitle
		{
			get => _reservationTitle;
			set => SetProperty(ref _reservationTitle, value);
		}

		public string NumberTitle
		{
			get => _numberTitle;
			set => SetProperty(ref _numberTitle, value);
		}

		public string LastNameTitle
		{
			get => _lastNameTitle;
			set => SetProperty(ref _lastNameTitle, value);
		}

		public string NameTitle
		{
			get => _nameTitle;
			set => SetProperty(ref _nameTitle, value);
		}

		public string PlaceTitle
		{
			get => _placeTitle;
			set => SetProperty(ref _placeTitle, value);
		}

        private async void ReservationCommandExecute()
		{
			IsEnabled = false;
            IsBusy = true;

            if (CrossConnectivity.Current.IsConnected)
            {
                var service = new PlaceService();

                if(PhoneNumber != null && FirstName != null && LastName != null)
                {
                    var res = await service.ReservationPlace(new Reservation
                    {
                        PhoneNumber = PhoneNumber,
                        Place = Place,
                        FirstName = FirstName,
                        LastName = LastName
                    });
					if (res)
					{
						await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, Properties.Strings.Theformwassuccessfullysent, Properties.Strings.Ok);
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, service.LastError, Properties.Strings.Ok);
					}
				}
                else
				{
					IsEnabled = true;
					await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, $"{Properties.Strings.Name},{Properties.Strings.LastName},{Properties.Strings.Number} {Properties.Strings.Notreading}", Properties.Strings.Ok);
				}
            }
            else
            {
                Title = Properties.Strings.WaitingForNetwork;
				await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, $"{Properties.Strings.Name},{Properties.Strings.LastName},{Properties.Strings.Number} {Properties.Strings.Notreading}", Properties.Strings.Ok);
			}
			IsBusy = false;
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
		{
			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			LastNameTitle = Properties.Strings.LastName;
			NumberTitle = Properties.Strings.Number;
			ReservationTitle = Properties.Strings.Reservation;
			RowTitle = Properties.Strings.Row;
		}

		public string RowTitle
		{
			get => _rowTitle;
			set => SetProperty(ref _rowTitle, value);
		}
	}
}
