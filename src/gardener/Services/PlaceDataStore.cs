﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class PlaceDataStore : BaseJsonDataStore<Place>
	{
		private readonly Uri _itemsUri;

		public PlaceDataStore(Uri getItemsUri)
		{
			_itemsUri = getItemsUri;
		}

		public new async Task<ObservableCollection<Place>> GetItemsAsync(bool forceRefresh = false)
		{
			if (Items.Count > 0 && !forceRefresh)
			{
				return await Task.FromResult(Items);
			}

			JsonDataResponse<Place> response = DownloadSerializedJsonData(_itemsUri);

			if (!response.Success)
			{
				throw new WebException("Произошла ошибка сервера.");
			}

			return Items = response.Data;
		}
	}
}
