using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	internal class FeedbackService
	{
		#region Properties
		public List<string> ErrorsList
		{
			get;
		} = new List<string>();

		public string LastError
		{
			get;
			set;
		}
		#endregion

		#region Public
		public async Task<bool> Send(string phoneNumber, Place place, int floor, Block block, string text, string name)
		{
			using (var client = new HttpClient())
			{
				var response = await client.PostAsync("http://tc.itmit-studio.ru/api/question/store",
													  new FormUrlEncodedContent(new Dictionary<string, string>
													  {
														  {
															  "phone_number", phoneNumber
														  },
														  {
															  "place_number", place.PlaceNumber
														  },
														  {
															  "row", place.Row
														  },
														  {
															  "block", block.OriginalTitle
														  },
														  {
															  "floor", floor.ToString()
														  },
														  {
															  "text", text
														  },
														  {
															  "name", name
														  }
													  }));
				var json = await response.Content.ReadAsStringAsync();

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
		#endregion
	}
}
