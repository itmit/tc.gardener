using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.ViewModels
{
	internal class FormappViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private ObservableCollection<Place> _placeCollection;
		#endregion
		#endregion

		#region .ctor
		#endregion

		#region Properties
		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set
			{
				_placeCollection = value;
				OnPropertyChanged(nameof(PlaceCollection));
			}
		}
		#endregion

		#region Public
		public async void SetSerializedJsonData(string url)
		{
			JsonDataResponse<ObservableCollection<Place>> response;
			await Task.Run(() =>
			{
				response = _download_serialized_json_data<JsonDataResponse<ObservableCollection<Place>>>(url);

				if (response.Success)
				{
					PlaceCollection = response.Data;
				}
			});
		}
		#endregion

		#region Private
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
