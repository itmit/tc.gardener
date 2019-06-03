using System.Collections.ObjectModel;
using gardener.Models;
using gardener.Views;
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
			Title = "Список свободных помещений";
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
					if (value.Floors.Count > 1)
					{
						_navigation.PushAsync(new SelectFloorPage(value));
					}
					else
					{
						_navigation.PushAsync(new ListSalePage(value, value.Floors[0].Value));
					}
					_selectedItem = null;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion
	}
}
