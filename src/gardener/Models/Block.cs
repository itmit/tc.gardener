using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace gardener.Models
{
	public class Block
	{
		public Block()
		{
			Floors = new List<Floor>
			{
				new Floor{ Value = 1 }
			};
		}

		#region Properties
		public string ImagePath
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		} = true;

		public string Title
		{
			get;
			set;
		}

		public ObservableCollection<Place> Places
		{
			get;
			private set;
		}

		public List<Floor> Floors
		{
			get;
			set;
		}
		#endregion


		#region Private

		public void SetPlaceFromApi(string url)
		{
			var response = _download_serialized_json_data<JsonDataResponse<ObservableCollection<Place>>>(url);

#if (DEBUG)
			Debug.WriteLine(response.Message);
#endif

			if (response.Success && response.Data != null)
			{
				Places = response.Data;
			}
		}

		private T _download_serialized_json_data<T>(string url) where T : new()
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(url);

				// if string with JSON data is not empty, deserialize it to class and return its instance 
				return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
			}
		}
		#endregion
	}
}
