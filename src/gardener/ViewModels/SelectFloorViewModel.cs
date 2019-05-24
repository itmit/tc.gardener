using System.Collections.Generic;
using gardener.Models;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class SelectFloorViewModel : BaseViewModel
	{
		private Block _block;
		private Floor _selectedItem;
		private INavigation _navigation;

		public SelectFloorViewModel(Block block, INavigation navigation)
		{
			Title = "Выбор этажа";
			_block = block;
			_navigation = navigation;
			Floors = block.Floors;
		}

		public List<Floor> Floors
		{
			get;
			set;
		}

		public Floor SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				if (value != null)
				{
					_navigation.PushAsync(new ListSalePage(_block, value.Value));
					_selectedItem = null;
				}
				OnPropertyChanged(nameof(SelectedItem));
			}
		}
	}
}
