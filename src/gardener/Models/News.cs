using Newtonsoft.Json;

namespace gardener.Models
{
	public class News
	{
		[JsonProperty("head")]
		public string Title
		{
			get;
			set;
		}

		[JsonProperty("picture")]
		public string ImageUrl
		{
			get;
			set;
		}

		[JsonProperty("body")]
		public string Text
		{
			get;
			set;
		}
	}
}
