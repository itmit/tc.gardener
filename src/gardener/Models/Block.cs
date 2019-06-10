using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность блок на рынке.
	/// </summary>
	public class Block
	{
		/// <summary>
		/// Инициализирует новый экземпляр типа <see cref="Block"/>>.
		/// </summary>
		public Block()
		{
			Floors = new List<Floor>
			{
				new Floor{ Value = 1 }
			};
		}

        #region Properties

        /// <summary>
        /// Возвращает или устанавливает физический путь к картинке.
        /// </summary>
        public string ImagePath
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает активность блока.
		/// </summary>
		public bool IsActive
		{
			get;
			set;
		} = true;

		/// <summary>
		/// Возвращает или устанавливает название блока.
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает коллекцию мест в блоке
		/// </summary>
		public ObservableCollection<Place> Places
		{
			get;
			private set;
		}

		/// <summary>
		/// Возвращает или устанавливает коллекцию этажей в блоке.
		/// </summary>
		public List<Floor> Floors
		{
			get;
			set;
		}
		#endregion


		#region Private

		/// <summary>
		/// Устанавливает места в блоке из внешнего api, по заданному адресу.
		/// </summary>
		/// <param name="url">Адрес внешнего сервиса.</param>
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

		/// <summary>
		/// Скачивает в формате json места в блоке.
		/// </summary>
		/// <typeparam name="T">Тип места в блоке.</typeparam>
		/// <param name="url">Адрес внешнего сервиса.</param>
		/// <returns></returns>
		private T _download_serialized_json_data<T>(string url) where T : new()
		{
			using (var w = new WebClient())
			{
				var jsonData = w.DownloadString(url);

				return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
			}
		}
		#endregion
	}
}
