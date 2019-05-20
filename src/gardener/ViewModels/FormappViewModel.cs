using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using gardener.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace gardener.ViewModels
{
	internal class FormAppViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private ObservableCollection<Place> _placeCollection;
		#endregion
		#endregion

		#region .ctor
		public FormAppViewModel()
		{
			_placeCollection = new ObservableCollection<Place>();
		}
		#endregion

		#region Properties
		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set => SetProperty(ref _placeCollection, value);
		}
		#endregion

		#region Public
		public async void SetSerializedJsonData(string url)
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				IsBusy = true;
				JsonDataResponse<ObservableCollection<Place>> response;
				await Task.Run(() =>
				{
					response = _download_serialized_json_data<JsonDataResponse<ObservableCollection<Place>>>(url);

#if (DEBUG)
					Console.WriteLine(response.Message);
#endif

					IsBusy = false;

					if (response.Success && response.Data != null)
					{
						PlaceCollection = response.Data;
					}
				});
			}
			else
			{
				// TODO: Показать сообщение о том, что нет сети.
			}
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
