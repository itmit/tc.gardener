using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.Services
{
	internal class FeedbackService : BaseService
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

		private const string SendUri = "{0}/api/question/store";

		#region Public
		public async Task<bool> Send(string phoneNumber, Place place, int floor, Block block, string text, string name, string type)
		{
			
			var response = await HttpClient.PostAsync(string.Format(SendUri, Domain),
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
													  },
													  {
														  "type", type
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
		#endregion
	}
}
