using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace gardener.Services
{
	public abstract class BaseJsonDataStore<T> : IDataStore<T>
	{
		public BaseJsonDataStore(string url)
		{
			Url = url;
			Items = new ObservableCollection<T>();
		}

		protected string Url
		{
			get;
		}

		protected ObservableCollection<T> Items
		{
			get;
			set;
		}

		public Task<bool> AddItemAsync(T item) => throw new System.NotImplementedException();

		public Task<bool> DeleteItemAsync(string id) => throw new System.NotImplementedException();

		public Task<T> GetItemAsync(string id) => throw new System.NotImplementedException();

		public Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false) => throw new System.NotImplementedException();

		public Task<bool> UpdateItemAsync(T item) => throw new System.NotImplementedException();

		/// <summary>
		/// Скачивает в формате json места в блоке.
		/// </summary>
		/// <typeparam name="T">Тип места в блоке.</typeparam>
		/// <returns></returns>
		protected JsonDataResponse<T> DownloadSerializedJsonData()
		{
			using (var w = new WebClient())
			{
				string jsonData = w.DownloadString(Url);

				if (string.IsNullOrEmpty(jsonData))
				{
					throw new WebSocketException($"Не удалось получить данные по адресу: {Url}");
				}

				return JsonConvert.DeserializeObject<JsonDataResponse<T>>(jsonData);
			}
		}

		protected async Task<bool> SendForm(Dictionary<string, string> parameters)
		{
			var client = new HttpClient();

			var encodedContent = new FormUrlEncodedContent(parameters);

			var response = await client.PostAsync(Url, encodedContent);

			return await Task.FromResult(response.IsSuccessStatusCode);
		}
	}
}
