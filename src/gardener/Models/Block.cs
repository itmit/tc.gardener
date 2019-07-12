using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность блок на рынке.
	/// </summary>
	public class Block
	{
		#region .ctor
		/// <summary>
		/// Инициализирует новый экземпляр типа <see cref="Block" />>.
		/// </summary>
		public Block() =>
			Floors = new List<Floor>
			{
				new Floor
				{
					Value = 1
				}
			};
		#endregion

		#region Properties
		/// <summary>
		/// Возвращает или устанавливает коллекцию этажей в блоке.
		/// </summary>
		public List<Floor> Floors
		{
			get;
			set;
		}

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
		/// Возвращает или устанавливает коллекцию мест в блоке
		/// </summary>
		public ObservableCollection<Place> Places
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает название блока.
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает оригинальное название блока, на русском.
		/// </summary>
		public string OriginalTitle
		{
			get;
			set;
		}
		#endregion
	}
}
