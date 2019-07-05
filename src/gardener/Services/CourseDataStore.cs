using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class CourseDataStore : IDataStore<Course>
	{
		private const string Url = "https://api.exchangerate-api.com/v4/latest/RUB";

		public Task<bool> AddItemAsync(Course item) => throw new System.NotImplementedException();

		public Task<bool> DeleteItemAsync(string id) => throw new System.NotImplementedException();

		public Task<Course> GetItemAsync(string id = "")
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(Url);

				if (string.IsNullOrEmpty(jsonData))
				{
					throw new WebSocketException($"Не удалось получить данные по адресу: {Url}");
				}

				return Task.FromResult(JsonConvert.DeserializeObject<Course>(jsonData));
			}
		}

		public Task<IEnumerable<Course>> GetItemsAsync(bool forceRefresh = false)
			=> throw new System.NotImplementedException();

		public Task<bool> UpdateItemAsync(Course item) => throw new System.NotImplementedException();
	}
}
