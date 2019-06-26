﻿using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class BidForSaleDataStore : BaseJsonDataStore<BidForSale>
	{
		#region .ctor
		public BidForSaleDataStore(string url)
			: base(url)
		{
		}
		#endregion

		#region Public
		public new async Task<bool> AddItemAsync(BidForSale item) =>
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
