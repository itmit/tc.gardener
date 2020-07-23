using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class BidService : BaseService
	{
		private const string CreateBidForBuyUri = "{0}/api/bidForSale";
		private const string CreateBidForSaleUri = "{0}/api/bidForBuy";

		public async Task<bool> CreateBidForBuy(Bid bid)
		{
			var response = await HttpClient.PostAsync(string.Format(CreateBidForBuyUri, Domain), 
													  new FormUrlEncodedContent(new Dictionary<string, string>
													  {
														  {
															  "Name", bid.Name
														  },
														  {
															  "PhoneNumber", bid.PhoneNumber
														  },
														  {
															  "Block", bid.Block.OriginalTitle
														  },
														  {
															  "Row", bid.Row
														  },
														  {
															  "Floor", bid.Floor.ToString()
														  },
														  {
															  "Text", bid.Text
														  }
													  }));

			var json = await response.Content.ReadAsStringAsync();

			if (string.IsNullOrEmpty(json))
			{
				return false;
			}

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			var data = JsonConvert.DeserializeObject<JsonAuthDataResponse<string>>(json);
			LastError = data.Data;
			return false;
		}

		public string LastError
		{
			get;
			private set;
		}

		public async Task<bool> CreateBidForSale(Bid bid)
		{
			var response = await HttpClient.PostAsync(string.Format(CreateBidForSaleUri, Domain),
												  new FormUrlEncodedContent(new Dictionary<string, string>
												  {
													  {
														  "PlaceNumber", bid.PlaceNumber
													  },
													  {
														  "Name", bid.Name
													  },
													  {
														  "PhoneNumber", bid.PhoneNumber
													  },
													  {
														  "Block", bid.Block.OriginalTitle
													  },
													  {
														  "Row", bid.Row
													  },
													  {
														  "Floor", bid.Floor.ToString()
													  },
													  {
														  "Text", bid.Text
													  }
												  }));

			var json = await response.Content.ReadAsStringAsync();

			if (string.IsNullOrEmpty(json))
			{
				return false;
			}

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			var data = JsonConvert.DeserializeObject<JsonAuthDataResponse<string>>(json);
			LastError = data.Data;
			return false;
		}
	}
}
