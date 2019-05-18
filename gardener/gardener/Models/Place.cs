using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace gardener.Models
{
	class Place
	{
		private static T _download_serialized_json_data<T>(string url) where T : new()
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(url);

				// if string with JSON data is not empty, deserialize it to class and return its instance 
				return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
			}
		}

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
