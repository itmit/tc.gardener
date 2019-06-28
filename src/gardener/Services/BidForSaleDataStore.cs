using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class BidForSaleDataStore : BaseJsonDataStore<BidForSale>
	{
		private readonly Uri _createUri;

		#region .ctor
		public BidForSaleDataStore(Uri addItemUri)
			: base()
		{
			_createUri = addItemUri;
		}
		#endregion

		#region Public
		public new async Task<bool> AddItemAsync(BidForSale item) =>
			await Task.FromResult(await SendForm(_createUri, new Dictionary<string, string>
			{
				{
					"PlaceNumber", item.PlaceNumber
				},
				{
					"Name", item.Name
				},
				{
					"PhoneNumber", item.PhoneNumber
				},
				{
					"Block", item.Block
				},
				{
					"Floor", item.Floor.ToString()
				}
			}));
		#endregion
	}
}
