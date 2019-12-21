using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class BidService
	{
		private const string CreateBidForBuyUri = "http://tc.itmit-studio.ru/api/bidForSale";
		private const string CreateBidForSaleUri = "http://tc.itmit-studio.ru/api/bidForBuy";

		public async Task<bool> CreateBidForBuy(Bid bid)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.PostAsync(CreateBidForBuyUri, 
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

				string json = await response.Content.ReadAsStringAsync();

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

		public string LastError
		{
			get;
			set;
		}

		public async Task<bool> CreateBidForSale(Bid bid)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await client.PostAsync(CreateBidForSaleUri,
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

				string json = await response.Content.ReadAsStringAsync();

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
}
