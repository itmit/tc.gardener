using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gardener.Models
{
	public class Market
	{
		public ObservableCollection<Block> Blocks
		{
			get;
		}

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
						new Floor {Value = "1 Этаж"},
						new Floor {Value = "2 Этаж"}
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
