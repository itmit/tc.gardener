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
					ImagePath = "veschevye_ryady.jpg",
					Title = "Вещевые ряды"
				},
				new Block
				{
					ImagePath = "tts_sadovod.jpg",
					Title = "ТЦ Садовод",
					Floors = new List<Floor>
					{
						new Floor {Value = 1},
						new Floor {Value = 2}
					}
				},
				new Block
				{
					ImagePath = "mex.png",
					Title = "Меха и кожа"
				},
				new Block
				{
                    ImagePath = "paltovy_krug.png",
                    Title = "Пальтовый круг"
				},
				new Block
				{
                    ImagePath = "svadebnaya_galereya_SALYuT.jpg",
                    Title = "Свадебная галерея 'САЛЮТ'"
				},
				new Block
				{
                    ImagePath = "kovr_tekst.jpg",
                    Title = "Ковры и текстиль"
				},
				new Block
				{
                    ImagePath = "novy_tts.png",
                    Title = "Новый ТЦ",
					IsActive = false
				}
			};
		}
	}
}
