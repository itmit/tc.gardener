﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class PlaceService :  BaseService
	{
		/// <summary>
		/// Адрес для бронирования мест.
		/// </summary>
		private const string ReservationPlaceUri = "{0}/api/place/makeReservation";
		
		/// <summary>
		/// Адрес для получения мест.
		/// </summary>
		private const string GetPlacesUri = "/api/places";

		public DateTime? ServerDate
		{
			get;
			private set;
		}

		/// <summary>
		/// Бронирует место.
		/// </summary>
		/// <param name="reservation">Параметры бронирования.</param>
		/// <returns>Возвращает <c>true</c> если бронирование успешно, иначе <c>false</c>.</returns>
		public async Task<bool> ReservationPlace(Reservation reservation)
		{
			var response = await HttpClient.PostAsync(string.Format(ReservationPlaceUri, Domain),
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
															  "row", reservation.Place.Row
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

			var jsonString = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(jsonString);

			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			var jsonData = JsonConvert.DeserializeObject<JsonAuthDataResponse<string>>(jsonString);
			
			LastError = jsonData.Data;
			
			return false;
		}

		public string LastError
		{
			get;
			private set;
		}

		/// <summary>
		/// Получает места в блоке.
		/// </summary>
		/// <param name="block">Блок на рынке.</param>
		/// <param name="floor">Этаж.</param>
		/// <param name="limit">Предельное количество получаемых мест.</param>
		/// <param name="offset">Количество пропущенных мест.</param>
		/// <returns>Список мест в блоке.</returns>
		public async Task<IEnumerable<Place>> GetPlaces(Block block, int floor, int limit = 100, int offset = 0)
		{
			var url = $"{Domain}{GetPlacesUri}/{block.OriginalTitle}?limit={limit}&offset={offset}&floor={floor}";
			var response = await HttpClient.GetAsync(url);

			var jsonString = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(jsonString);

			if (string.IsNullOrEmpty(jsonString))
			{
				return new List<Place>();
			}

			if (!response.IsSuccessStatusCode)
			{
				return new List<Place>();
			}

			var jsonData = JsonConvert.DeserializeObject<JsonDataResponse<Place>>(jsonString);
			ServerDate = jsonData.ServerDate;
			return jsonData.Data;

		}
	}
}
