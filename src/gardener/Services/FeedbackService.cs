using gardener.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gardener.Services
{
	class FeedbackService
	{
		public async Task<bool> Send(string phoneNumber, string text, string name)
		{
			using (var client = new HttpClient())
			{
				var encodedContent = new FormUrlEncodedContent(new Dictionary<string, string> 
				{
					{ "phone_number", phoneNumber },
					{ "text", text },
					{ "name", name }
				});

				var response = await client.PostAsync("http://tc.itmit-studio.ru/api/question/store", encodedContent);
				if (!response.IsSuccessStatusCode)
				{
					var jsonString = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(jsonString);
					if (jsonString != null)
					{
						var jsonData = JsonConvert.DeserializeObject<JsonDataResponse<string>>(jsonString);
						foreach (var errorString in jsonData.Data)
						{
							ErrorsList.Add(errorString);
						}
					}
				}

				return await Task.FromResult(response.IsSuccessStatusCode);
			}
		}

		public List<string> ErrorsList
		{
			get;
		} = new List<string>();
	}
}
