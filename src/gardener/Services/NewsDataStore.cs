﻿using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class NewsDataStore : BaseJsonDataStore<News>
	{
		private readonly Uri _itemsUri;

		public NewsDataStore(Uri getItemsUri) => _itemsUri = getItemsUri;

		public NewsDataStore() => _itemsUri = new Uri("http://tc.itmit-studio.ru/api/news");

		public new async Task<ObservableCollection<News>> GetItemsAsync(bool forceRefresh = false)
		{
			if (Items.Count > 0 && !forceRefresh)
			{
				return await Task.FromResult(Items);
			}

			JsonDataResponse<News> response = DownloadSerializedJsonData(_itemsUri);

			if (!response.Success)
			{
				throw new WebException("Произошла ошибка сервера.");
			}

			return Items = response.Data;
		}
	}
}
