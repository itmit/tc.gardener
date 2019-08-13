using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;

namespace gardener.ViewModels
{
	internal class FormAppViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly Block _block;
		private readonly int _floor;
		private ObservableCollection<Place> _placeCollection;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel(Block block)
		{
			_block = block;
			_placeCollection = new ObservableCollection<Place>();

			Title = Properties.Strings.FreePlace;
		}

       // Replaced = new ReplacedCommand({
       // });

        public FormAppViewModel(Block block, int floor)
		{
			_block = block;
			_floor = floor;
			_placeCollection = new ObservableCollection<Place>();

			Title = Properties.Strings.FreePlace;
		}
		#endregion

		#region Properties
		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set => SetProperty(ref _placeCollection, value);
		}
		#endregion

		#region Public
		public async void SetSerializedJsonDataAsync(bool force = false)
		{
			if (_block.Places == null)
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
