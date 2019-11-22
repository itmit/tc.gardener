using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using gardener.Models;
using gardener.Services;
using gardener.Views;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	internal class FormAppViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly Block _block;
		private readonly int _floor;
		private ObservableCollection<PlaceViewModel> _placeCollection;
		private PlaceViewModel _selectedPlace;
		private readonly INavigation _navigation;
		private readonly Timer _timer;
		private DateTime? _serverDate;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel(Block block, INavigation navigation)
		{
			_navigation = navigation;
			_block = block;
			_placeCollection = new ObservableCollection<PlaceViewModel>();

			Title = Properties.Strings.FreePlace;
			_timer = new Timer(UpdatePlaceList, null, 0, 15000);
		}

        public FormAppViewModel(Block block, int floor, INavigation navigation)
		{
			_block = block;
			_floor = floor;
			_placeCollection = new ObservableCollection<PlaceViewModel>();

			Title = Properties.Strings.FreePlace;

			_timer = new Timer(UpdatePlaceList, null, 0, 15000);
		}
		#endregion

		private void UpdatePlaceList(object obj)
		{
			if (_timer == null)
			{
				return;
			}

			Task.Run(() =>
			{
				SetSerializedJsonDataAsync(true);
			});
		}

		#region Properties
		public PlaceViewModel SelectedPlace
		{
			get => _selectedPlace;
			set
			{
				_selectedPlace = value;

				if (value != null)
				{
					if (value.Place.Status == "Забронировано")
					{
						Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, Properties.Strings.BlockedPlace, Properties.Strings.Ok);
						OnPropertyChanged(nameof(SelectedPlace));
						return;
					}

					_navigation.PushAsync(new ReservationPage(_selectedPlace.Place));
					
					_selectedPlace = null;
				}

				OnPropertyChanged(nameof(SelectedPlace));
			}
		}

		public ObservableCollection<PlaceViewModel> PlaceCollection
		{
			get => _placeCollection;
			set => SetProperty(ref _placeCollection, value);
		}
		#endregion

		#region Public
		public async void SetSerializedJsonDataAsync(bool force = false)
		{
			ObservableCollection<Place> collection;
			if (_block.Places == null || force)
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					var service = new PlaceDataStore();

					IsBusy = true;
					_block.Places = new ObservableCollection<Place>(await service.GetItemsFromBlockAsync(_block, _block.Places != null && _block.Places.Count > 0 || force));
					_serverDate = service.LastDataResponse.ServerDate;

					collection = _floor > 0 ? new ObservableCollection<Place>(_block.Places.Where(x => x.Floor == _floor)) : _block.Places;
				}
				else
				{
					collection = _block.Places;
					Title = Properties.Strings.WaitingForNetwork;
				}
			}
			else
			{
				collection = _block.Places;
			}

			ObservableCollection<PlaceViewModel> places = new ObservableCollection<PlaceViewModel>();
			if (collection != null)
			{
				foreach (var place in collection)
				{
					places.Add(new PlaceViewModel(place, _serverDate));
				}
			}

			PlaceCollection = places;
			IsBusy = false;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			SetSerializedJsonDataAsync(true);
			Title = Properties.Strings.FreePlace;
		}
	}
}
