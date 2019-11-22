using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace gardener.Models
{
	/// <summary>
	/// Представляет тип для данных возвращаемые от внешнего сервиса в формате json.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonDataResponse<T>
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает данные возвращаемые от сервиса.
		/// </summary>
		public ObservableCollection<T> Data
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает возвращаемое сообщение сообщение.
		/// </summary>
		public string Message
		{
			get;
			set;
		} = "";

		/// <summary>
		/// Возвращает или устанавливает статус ответа.
		/// </summary>
		public bool Success
		{
			get;
			set;
		} = false;

		[JsonProperty("date")]
		public DateTime? ServerDate
		{
			get;
			set;
		}
		#endregion
	}
}
