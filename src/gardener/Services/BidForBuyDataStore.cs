using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class BidForBuyDataStore : BaseJsonDataStore<BidForBuy>
	{
		private readonly Uri _createUri;

		public BidForBuyDataStore(Uri addItemUri) => _createUri = addItemUri;

		#region Public
		public new async Task<bool> AddItemAsync(BidForBuy item) =>
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
