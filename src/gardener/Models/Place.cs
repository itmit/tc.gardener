using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность места в блоке.
	/// </summary>
	public class Place : INotifyPropertyChanged
	{
		private string _expiresIn;

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

		[JsonProperty("reservation")]
		public DateTime? ReservationDate
		{
			get;
			set;
		}
		#endregion

		public void NotifyStatusChanged()
		{
			OnPropertyChanged(nameof(Status));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Annotations.NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
