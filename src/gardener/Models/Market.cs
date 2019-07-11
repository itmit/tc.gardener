﻿using System.Collections.Generic;
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
					ImagePath = "veschevye_ryady.jpg",
					Title = Properties.Strings.Clothingseries
                },
				new Block
				{
					ImagePath = "tts_sadovod.jpg",
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
					}
				},
				new Block
				{
					ImagePath = "mex.png",
					Title = Properties.Strings.Furandleather
                },
				new Block
				{
					ImagePath = "paltovy_krug.png",
					Title = Properties.Strings.Coatcircle
                },
				new Block
				{
					ImagePath = "svadebnaya_galereya_SALYuT.jpg",
					Title = Properties.Strings.Weddinggallery
                },
				new Block
				{
					ImagePath = "kovr_tekst.jpg",
					Title = Properties.Strings.Carpetsandtextiles
                },
				new Block
				{
					ImagePath = "novy_tts.png",
					Title = Properties.Strings.Thenewshoppingcenter,
					IsActive = false
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
