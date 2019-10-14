﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
    /// <summary>
    /// Представляет ViewModel для <see cref="ReservationPage" />
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
        private Action<bool> _callBack;

        public ReservationViewModel(INavigation navigation, Place place, Action<bool> callBack)
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

            _callBack = callBack;
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

        private void ReservationCommandExecute()
		{
            IsBusy = true;

            if (CrossConnectivity.Current.IsConnected)
            {
                var service = new PlaceDataStore();

                if(PhoneNumber != null && FirstName != null && LastName != null)
                {
                    service.ReservationPlace(new Reservation
                    {
                        PhoneNumber = PhoneNumber,
                        Place = Place,
                        FirstName = FirstName,
                        LastName = LastName
                    });
                    _callBack(true);
                }
                else
                {
                    _callBack(false);
                }
            }
            else
            {
                Title = Properties.Strings.WaitingForNetwork;
                _callBack(false);
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
