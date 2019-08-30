using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	public class NewsService
	{
		private const string HourlyNewsUri = "http://tc.itmit-studio.ru/api/news/hourlyNews";


		public async Task<IEnumerable<News>> GetHourlyNews()
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage responseMessage = await client.GetAsync(HourlyNewsUri);

				string jsonString = await responseMessage.Content.ReadAsStringAsync();

				if (jsonString != null)
				{
					var jsonData = JsonConvert.DeserializeObject<JsonDataResponse<News>>(jsonString);

					return await Task.FromResult(jsonData.Data);
				}

				return await Task.FromResult(new List<News>());
			}
		}
	}
}
