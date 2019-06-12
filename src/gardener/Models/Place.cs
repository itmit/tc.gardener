using Newtonsoft.Json;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность места в блоке.
	/// </summary>
	public class Place
	{
		#region Properties

		/// <summary>
		/// Возвращает или устанавливает название блока, в котором находится место.
		/// </summary>
		public string Block
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает номер этажа на котором находится место.
		/// </summary>
		public int? Floor
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает номер места в блоке.
		/// </summary>
		[JsonProperty("place_number")]
		public string PlaceNumber
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает стоимость блока
		/// </summary>
		public int? Price
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ряд в котором находится место.
		/// </summary>
		public string Row
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает статус места.
		/// </summary>
		public string Status
		{
			get;
			set;
		}
		#endregion
	}
}
