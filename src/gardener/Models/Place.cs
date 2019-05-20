using Newtonsoft.Json;

namespace gardener.Models
{
	internal class Place
	{
		#region Properties
		public string Block
		{
			get;
			set;
		}

		public int Floor
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		[JsonProperty("place_number")]
		public string PlaceNumber
		{
			get;
			set;
		}

		public int Price
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}
		#endregion
	}
}
