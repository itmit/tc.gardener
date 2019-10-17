using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
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
		private const string ReservationPlaceUri = "http://tc.itmit-studio.ru/api/place/makeReservation";
		#endregion
		#endregion

		#region Public
		public override Task<bool> AddItemAsync(Place item) => throw new NotImplementedException();

		public override Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();

		public override Task<Place> GetItemAsync(string id) => throw new NotImplementedException();

		public async void ReservationPlace(Reservation reservation)
		{
			HttpResponseMessage response;
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				response = await client.PostAsync(
							   ReservationPlaceUri,
							   new FormUrlEncodedContent(new Dictionary<string, string>
							   {
								   {
									   "first_name", reservation.FirstName
								   },
								   {
									   "last_name", reservation.LastName
								   },
								   {
									   "phone", reservation.PhoneNumber
								   },
								   {
									   "block", reservation.Place.Block
								   },
								   {
									   "floor", reservation.Place.Floor.ToString()
								   },
								   {
									   "place_number", reservation.Place.PlaceNumber
								   }
							   }));
			}

			var jsonString = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(jsonString);

			if (response.IsSuccessStatusCode)
			{
				if (jsonString != null)
				{
					return;
				}

				throw new NoNullAllowedException("Нет ответа от сервера.");
			}
		}

		public override async Task<IEnumerable<Place>> GetItemsAsync(bool forceRefresh = false)
		{
			if (Items.Count > 0 && !forceRefresh)
			{
				return await Task.FromResult(Items);
			}

			var response = DownloadSerializedJsonData(new Uri(Url + $"/{_block.OriginalTitle}"));

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
