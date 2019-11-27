using System;
using System.Collections.ObjectModel;
using System.Linq;
using gardener.Models;
using gardener.Properties;
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
		private readonly INavigation _navigation;
		private ObservableCollection<PlaceViewModel> _placeCollection;
		private string _placeTitle;
		private string _rowTitle;
		private PlaceViewModel _selectedPlace;
		private DateTime? _serverDate;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel(Block block, INavigation navigation)
		{
			_navigation = navigation;
			_block = block;
			_placeCollection = new ObservableCollection<PlaceViewModel>();
			SetStrings();
		}

		public FormAppViewModel(Block block, int floor, INavigation navigation)
		{
			_block = block;
			_floor = floor;
			_placeCollection = new ObservableCollection<PlaceViewModel>();
			SetStrings();
		}
		#endregion

		#region Properties
		public ObservableCollection<PlaceViewModel> PlaceCollection
		{
			get => _placeCollection;
			set => SetProperty(ref _placeCollection, value);
		}

		public string PlaceTitle
		{
			get => _placeTitle;
			set => SetProperty(ref _placeTitle, value);
		}

		public string RowTitle
		{
			get => _rowTitle;
			set => SetProperty(ref _rowTitle, value);
		}

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
						Application.Current.MainPage.DisplayAlert(Strings.Attention, Strings.BlockedPlace, Strings.Ok);
						OnPropertyChanged(nameof(SelectedPlace));
						return;
					}

					_navigation.PushAsync(new ReservationPage(_selectedPlace.Place));

					_selectedPlace = null;
				}

				OnPropertyChanged(nameof(SelectedPlace));
			}
		}
		#endregion

		#region Public
		public async void LoadData(int limit = 100, int offset = 0)
		{
			ObservableCollection<Place> collection;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new PlaceService();

				IsBusy = true;
				_block.Places = new ObservableCollection<Place>(await service.GetPlaces(_block, limit, offset));
				_serverDate = service.ServerDate;

				collection = _floor > 0 ? new ObservableCollection<Place>(_block.Places.Where(x => x.Floor == _floor)) : _block.Places;
			}
			else
			{
				collection = _block.Places;
				Title = Strings.WaitingForNetwork;
			}

			if (collection != null)
			{
				foreach (var place in collection)
				{
					PlaceCollection.Add(new PlaceViewModel(place, _serverDate));
				}
			}

			IsBusy = false;
		}
		#endregion

		#region Overrided
		protected override void OnLanguageChanged()
		{
			Title = Strings.FreePlace;
		}
		#endregion

		#region Private
		private void SetStrings()
		{
			Title = Strings.FreePlace;
			RowTitle = Strings.Row;
			PlaceTitle = Strings.Place;
		}
		#endregion
	}
}
