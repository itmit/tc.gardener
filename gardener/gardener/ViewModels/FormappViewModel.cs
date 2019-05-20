using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using gardener.Annotations;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.ViewModels
{
	class FormappViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Place> _placeCollection;

		public FormappViewModel()
		{
		}

		public async void SetSerializedJsonData(string url)
		{
			JsonDataResponse<ObservableCollection<Place>> response = null;
			await Task.Run(() =>
			{
				response = _download_serialized_json_data<JsonDataResponse<ObservableCollection<Place>>>(url);

				if (response.Success)
				{
					PlaceCollection = response.Data;
				}
			});
		}

		private T _download_serialized_json_data<T>(string url) where T : new()
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(url);

				// if string with JSON data is not empty, deserialize it to class and return its instance 
				return !String.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
			}
		}

		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set
			{
				_placeCollection = value;
				OnPropertyChanged(nameof(PlaceCollection));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
