using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class BidForBuyDataStore : BaseJsonDataStore<BidForBuy>
	{
		public BidForBuyDataStore(string url)
			: base(url)
		{
		}

		#region Public
		public new async Task<bool> AddItemAsync(BidForBuy item) =>
			await Task.FromResult(await SendForm(new Dictionary<string, string>
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
