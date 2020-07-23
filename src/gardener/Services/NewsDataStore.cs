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
		private const string NewsUri = "{0}/api/news";
		#endregion
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

			var response = DownloadSerializedJsonData(new Uri(string.Format(NewsUri, Domain)));

			if (!response.Success)
			{
				throw new WebException("Произошла ошибка сервера.");
			}

			Items = response.Data;

			foreach (var item in Items)
			{
				item.ImageUrl = Domain + item.ImageUrl;
			}

			return Items;
		}

		public override Task<bool> UpdateItemAsync(News item) => throw new NotImplementedException();
		#endregion
	}
}
