﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;

namespace gardener.Services
{
	public class BidForSaleDataStore : BaseJsonDataStore<BidForSale>
	{
		#region Data
		#region Fields		
		private const string Url = "http://tc.itmit-studio.ru/api/bidForSale";

		#endregion
		#endregion

		#region Public
		public override async Task<bool> AddItemAsync(BidForSale item) =>
			await Task.FromResult(await SendForm(new Uri(Url), 
												 new Dictionary<string, string>
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
														 "Block", item.Block.OriginalTitle
													 },
													 {
														 "Floor", item.Floor.ToString()
													 }
												 }));

		public override Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();

		public override Task<BidForSale> GetItemAsync(string id) => throw new NotImplementedException();

		public override Task<IEnumerable<BidForSale>> GetItemsAsync(bool forceRefresh = false) => throw new NotImplementedException();

		public override Task<bool> UpdateItemAsync(BidForSale item) => throw new NotImplementedException();
		#endregion
	}
}
