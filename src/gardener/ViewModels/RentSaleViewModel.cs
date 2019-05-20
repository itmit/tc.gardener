using System.Collections.ObjectModel;
using gardener.Models;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	internal class RentSaleViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private ObservableCollection<Block> _blocks;

		private readonly INavigation _navigation;
		private Block _selectedItem;
		#endregion
		#endregion

		#region .ctor
		public RentSaleViewModel(INavigation navigation)
		{
			_navigation = navigation;
			_blocks = new ObservableCollection<Block>
			{
				new Block
				{
					ImagePath = "pict_3.png",
					Title = "Вещевые ряды"
				},
				new Block
				{
					ImagePath = "pict_4.png",
					Title = "ТЦ Садовод"
				},
				new Block
				{
					ImagePath = "pict_5.png",
					Title = "Меха и кожа"
				}
			};
		}
		#endregion

		#region Properties
		public ObservableCollection<Block> Blocks
		{
			get => _blocks;
			set
			{
				_blocks = value;
				OnPropertyChanged(nameof(Blocks));
			}
		}

		public Block SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				if (value != null)
				{
					_navigation.PushAsync(new ListSale(value));
					_selectedItem = null;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion
	}
}
