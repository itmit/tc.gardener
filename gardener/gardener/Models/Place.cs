using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace gardener.Models
{
	class Place
	{
		public int Id
		{
			get;
			set;
		}

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

		[JsonProperty("place_number")]
		public string PlaceNumber
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}

		public int Price
		{
			get;
			set;
		}
	}
}
