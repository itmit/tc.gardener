﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace gardener.ViewModels
{
	internal class FormAppViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private ObservableCollection<Place> _placeCollection;
		private Block _block;
		private readonly int _floor;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel(Block block)
		{
			Title = "Свободные места";
			_block = block;
			_placeCollection = new ObservableCollection<Place>();
		}


		public FormAppViewModel(Block block, int floor)
		{
			Title = "Свободные места";
			_block = block;
			_floor = floor;
			_placeCollection = new ObservableCollection<Place>();
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
		public async void SetSerializedJsonData(string url)
		{
			if (_block.Places == null)
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					IsBusy = true;
					await Task.Run(() =>
					{
						_block.SetPlaceFromApi(url);
						if (_floor > 0)
						{
							PlaceCollection = (ObservableCollection<Place>)_block.Places.Where(x => x.Floor == _floor);
						}
						else
						{
							PlaceCollection = _block.Places;
						}
						IsBusy = false;
					});
				}
				else
				{
					Title = "Ожидание сети";
				}
			}
			else
			{
				PlaceCollection = _block.Places;
			}
		}

		#endregion

	}
}
