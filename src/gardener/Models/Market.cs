using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace gardener.Models
{
	/// <summary>
	/// Представляет сущность рынок.
	/// </summary>
	public class Market
	{
		#region .ctor
		/// <summary>
		/// Инициализирует экземпляр типа <see cref="Market" />, с жестко заданными блоками.
		/// </summary>
		public Market() =>
			Blocks = new ObservableCollection<Block>
			{
				new Block
				{
					ImagePath = "veschevye_ryady.png",
					Title = Properties.Strings.Clothingseries,
					OriginalTitle = "Вещевые ряды"
				},
				new Block
				{
					ImagePath = "tts_sadovod.png",
					Title = Properties.Strings.Ttsgreenthumb,
					Floors = new List<Floor>
					{
						new Floor
						{
							Value = 1
						},
						new Floor
						{
							Value = 2
						}
					},
					OriginalTitle = "ТЦ Садовод"
				},
				new Block
				{
					ImagePath = "mex.png",
					Title = Properties.Strings.Furandleather,
					OriginalTitle = "Меха и кожа"
				},
				new Block
				{
					ImagePath = "paltovy_krug.png",
					Title = Properties.Strings.Coatcircle,
					OriginalTitle = "Пальтовый круг"
				},
				new Block
				{
					ImagePath = "svadebnaya_galereya_SALYuT.png",
					Title = Properties.Strings.Weddinggallery,
					OriginalTitle = "Свадебная галерея 'САЛЮТ'"
				},
				new Block
				{
					ImagePath = "kovr_tekst.png",
					Title = Properties.Strings.Carpetsandtextiles,
					OriginalTitle = "Ковры и текстиль"
				},
                new Block
				{
					ImagePath = "novy_tts.png",
					Title = Properties.Strings.Thenewshoppingcenter,
                    Floors = new List<Floor>
                    {
                        new Floor
                        {
                            Value = 1
                        },
                        new Floor
                        {
                            Value = 2
                        }
                    },
                    OriginalTitle = "Новый ТЦ"
				}
			};
		#endregion

		#region Properties
		/// <summary>
		/// Возвращает или устанавливает блоки на рынке.
		/// </summary>
		public ObservableCollection<Block> Blocks
		{
			get;
		}
		#endregion
	}
}
