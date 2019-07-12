using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class NewsDataStore : BaseJsonDataStore<News>
	{
		#region Data
		#region Fields
		private readonly Uri _itemsUri;
		#endregion
		#endregion

		#region .ctor
		public NewsDataStore(Uri getItemsUri) => _itemsUri = getItemsUri;

		public NewsDataStore() => _itemsUri = new Uri("http://tc.itmit-studio.ru/api/news");
		#endregion

		#region Public
		public override Task<bool> AddItemAsync(News item) => throw new NotImplementedException();

		public override Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();

		public override Task<News> GetItemAsync(string id) => throw new NotImplementedException();

		public override async Task<IEnumerable<News>> GetItemsAsync(bool forceRefresh = false)
		{
			if (Items.Count > 0 && !forceRefresh)
			{
				return await Task.FromResult(Items);
			}

			var response = DownloadSerializedJsonData(_itemsUri);

			if (!response.Success)
			{
				throw new WebException("Произошла ошибка сервера.");
			}

			Items = response.Data;

			foreach (var item in Items)
			{
				item.ImageUrl = "http://" + _itemsUri.Host + item.ImageUrl;
			}

			return Items;
		}

		public override Task<bool> UpdateItemAsync(News item) => throw new NotImplementedException();
		#endregion
	}
}
