using System.Collections.ObjectModel;
using System.ComponentModel;
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
		private ObservableCollection<Block> _blocks;
		private readonly INavigation _navigation;
		private Block _selectedItem;
		#endregion
		#endregion

		#region .ctor
		public RentSaleViewModel(INavigation navigation)
		{
			Title = Properties.Strings.RentSalePageTitle;
			_blocks = Market.Blocks;
			_navigation = navigation;

			Market = new Market();
			Blocks = Market.Blocks;
			Title = Properties.Strings.RentSalePageTitle;
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
					if (value.Title == Properties.Strings.Thenewshoppingcenter)
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
						_navigation.PushAsync(new ListSalePage(value,
															   value.Floors[0]
																	.Value));
					}

					_selectedItem = null;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			Market = new Market();
			Blocks = Market.Blocks;
			Title = Properties.Strings.RentSalePageTitle;
		}
	}
}
