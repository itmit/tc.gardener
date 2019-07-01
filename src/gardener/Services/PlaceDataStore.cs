using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class PlaceDataStore : BaseJsonDataStore<Place>
	{
		#region Data
		#region Fields
		private readonly Uri _itemsUri;
		#endregion
		#endregion

		#region .ctor
		public PlaceDataStore(Uri getItemsUri) => _itemsUri = getItemsUri;
		#endregion

		#region Public
		public new async Task<ObservableCollection<Place>> GetItemsAsync(bool forceRefresh = false)
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

			return Items = response.Data;
		}
		#endregion
	}
}
