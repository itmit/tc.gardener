using Newtonsoft.Json;

namespace gardener.Models
{
	public class News
	{
		#region Properties
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

		[JsonProperty("head")]
		public string Title
		{
			get;
			set;
		}
		#endregion
	}
}
