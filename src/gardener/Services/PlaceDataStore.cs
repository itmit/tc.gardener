using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class PlaceDataStore : BaseJsonDataStore<Place>
	{
		private Block _block;

		#region Data
		#region Fields
		private const string Url = "http://tc.itmit-studio.ru/api/places";
		#endregion
		#endregion

		#region Public
		public override Task<bool> AddItemAsync(Place item) => throw new NotImplementedException();

		public override Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();

		public override Task<Place> GetItemAsync(string id) => throw new NotImplementedException();

		public override async Task<IEnumerable<Place>> GetItemsAsync(bool forceRefresh = false)
		{
			if (Items.Count > 0 && !forceRefresh)
			{
				return await Task.FromResult(Items);
			}

			var response = DownloadSerializedJsonData(new Uri(Url + $"/{_block.OriginalTitle}/Свободен"));

			if (!response.Success)
			{
				throw new WebException("Произошла ошибка сервера.");
			}

			return Items = response.Data;
		}

		public override Task<bool> UpdateItemAsync(Place item) => throw new NotImplementedException();


		public async Task<IEnumerable<Place>> GetItemsFromBlockAsync(Block block, bool forceRefresh = false)
		{
			_block = block;
			return await GetItemsAsync(forceRefresh);
		}
		#endregion
	}
}
