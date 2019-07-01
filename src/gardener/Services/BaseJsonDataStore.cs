﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public abstract class BaseJsonDataStore<T> : IDataStore<T>
	{
		#region Data
		#region Fields
		public List<string> ErrorsList = new List<string>();
		#endregion
		#endregion

		#region .ctor
		public BaseJsonDataStore() => Items = new ObservableCollection<T>();
		#endregion

		#region Properties
		protected ObservableCollection<T> Items
		{
			get;
			set;
		}
		#endregion

		#region Protected
		/// <summary>
		/// Скачивает в формате json места в блоке.
		/// </summary>
		/// <typeparam name="T">Тип места в блоке.</typeparam>
		/// <returns></returns>
		protected JsonDataResponse<T> DownloadSerializedJsonData(Uri uri)
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(uri);

				if (string.IsNullOrEmpty(jsonData))
				{
					throw new WebSocketException($"Не удалось получить данные по адресу: {uri.AbsoluteUri}");
				}

				return JsonConvert.DeserializeObject<JsonDataResponse<T>>(jsonData);
			}
		}

		protected async Task<bool> SendForm(Uri uri, Dictionary<string, string> parameters)
		{
			var client = new HttpClient();

			var encodedContent = new FormUrlEncodedContent(parameters);

			var response = await client.PostAsync(uri, encodedContent);

			if (!response.IsSuccessStatusCode)
			{
				var jsonString = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(jsonString);
				if (jsonString != null)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonDataResponse<string>>(jsonString);
					ErrorsList.Add(jsonData.Message);
				}
			}

			return await Task.FromResult(response.IsSuccessStatusCode);
		}
		#endregion

		#region IDataStore<T> members
		public Task<bool> AddItemAsync(T item) => throw new NotImplementedException();

		public Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();

		public Task<T> GetItemAsync(string id) => throw new NotImplementedException();

		public Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false) => throw new NotImplementedException();

		public Task<bool> UpdateItemAsync(T item) => throw new NotImplementedException();
		#endregion
	}
}
