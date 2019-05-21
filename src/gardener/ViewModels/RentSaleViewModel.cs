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
		private readonly INavigation _navigation;
		private Block _selectedItem;
		private ObservableCollection<Block> _blocks;
		#endregion
		#endregion

		#region .ctor
		public RentSaleViewModel(INavigation navigation)
		{
			_blocks = Market.Blocks;
			_navigation = navigation;
		}
		#endregion

		#region Properties
		public ObservableCollection<Block> Blocks
		{
			get => _blocks;
			set => SetProperty(ref _blocks, value);
		}

		public Block SelectedItem
		{
			get => _selectedItem;
			set
			{
				if (value != null)
				{
					if (value.Title == "Новый ТЦ")
					{
						return;
					}
				}

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
