using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class BidForSaleDataStore : BaseJsonDataStore<BidForSale>
	{

		public BidForSaleDataStore(string url)
			: base(url)
		{

		}

		public new async Task<bool> AddItemAsync(BidForSale item) => await Task.FromResult(await SendForm(item));
	}
}
