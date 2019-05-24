using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность рынок.
	/// </summary>
	public class Market
	{
		/// <summary>
		/// Возвращает или устанавливает блоки на рынке.
		/// </summary>
		public ObservableCollection<Block> Blocks
		{
			get;
		}

		/// <summary>
		/// Инициализирует экземпляр типа <see cref="Market"/>, с жестко заданными блоками.
		/// </summary>
		public Market()
		{
			Blocks = new ObservableCollection<Block>
			{
				new Block
				{
					ImagePath = "pict_3.png",
					Title = "Вещевые ряды"
				},
				new Block
				{
					ImagePath = "pict_4.png",
					Title = "ТЦ Садовод",
					Floors = new List<Floor>
					{
						new Floor {Value = 1},
						new Floor {Value = 2}
					}
				},
				new Block
				{
					ImagePath = "pict_5.png",
					Title = "Меха и кожа"
				},
				new Block
				{
					Title = "Пальтовый круг"
				},
				new Block
				{
					Title = "Свадебная галерея 'САЛЮТ'"
				},
				new Block
				{
					Title = "Ковры и текстиль"
				},
				new Block
				{
					Title = "Новый ТЦ",
					IsActive = false
				}
			};
		}
	}
}
