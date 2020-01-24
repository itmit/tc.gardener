using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class CourseDataStore
	{
		private const string Url = "https://openexchangerates.org/api/latest.json?app_id=1d306ad7ee394fbf9ea29eb519d42296&base=rub";

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
	}
}
