using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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
		private ObservableCollection<Place> _placeCollection;
		private Place _selectedPlace;
		private readonly INavigation _navigation;
		private readonly Timer _timer;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel(Block block, INavigation navigation)
		{
			_navigation = navigation;
			_block = block;
			_placeCollection = new ObservableCollection<Place>();

			Title = Properties.Strings.FreePlace;
			_timer = new Timer(UpdatePlaceList, null, 0, 15000);
		}

        public FormAppViewModel(Block block, int floor, INavigation navigation)
		{
			_block = block;
			_floor = floor;
			_placeCollection = new ObservableCollection<Place>();

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

			SetSerializedJsonDataAsync(true);
		}

		#region Properties
		public Place SelectedPlace
		{
			get => _selectedPlace;
			set
			{
				_selectedPlace = value;

				if (value != null)
				{
					if (value.Status == "Забронировано")
					{
						Application.Current.MainPage.DisplayAlert("Внимание", "Выбранное место забронировано.", Properties.Strings.Ok);
						OnPropertyChanged(nameof(SelectedPlace));
						return;
					}

					_navigation.PushAsync(new ReservationPage(_selectedPlace));
					
					_selectedPlace = null;
				}

				OnPropertyChanged(nameof(SelectedPlace));
			}
		}

		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set => SetProperty(ref _placeCollection, value);
		}
		#endregion

		#region Public
		public async void SetSerializedJsonDataAsync(bool force = false)
		{
			if (_block.Places == null || force)
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					var service = new PlaceDataStore();

					IsBusy = true;
					_block.Places = (ObservableCollection<Place>)await service.GetItemsFromBlockAsync(_block, _block.Places != null && _block.Places.Count > 0 || force);
					
					if (_floor > 0)
					{
						PlaceCollection = (ObservableCollection<Place>) _block.Places.Where(x => x.Floor == _floor);
					}
					else
					{
						PlaceCollection = _block.Places;
					}

					IsBusy = false;
				}
				else
				{
					Title = Properties.Strings.WaitingForNetwork;
				}
			}
			else
			{
				PlaceCollection = _block.Places;
			}
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			SetSerializedJsonDataAsync(true);
			Title = Properties.Strings.FreePlace;
		}
	}
}
