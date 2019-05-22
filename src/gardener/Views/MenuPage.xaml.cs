using System.Collections.Generic;
using gardener.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		#region .ctor
		public MenuPage()
		{
			InitializeComponent();

			var menuItems = new List<HomeMenuItem>
			{
				new HomeMenuItem
				{
					Id = MenuItemType.Rent,
					Title = "Аренда торговых помещений"
                },
                new HomeMenuItem
                {
                    Id = MenuItemType.Map,
                    Title = "Схема рынка"
                },
				new HomeMenuItem
				{
					Id = MenuItemType.Selling,
					Title = "Вызов мастера (лайон)"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.CallSecurity,
					Title = "Вызов охраны"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.EmployCall,
					Title = "Вызов врача"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.CallSecurity,
					Title = "Котировки валют"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Purchase,
					Title = "Новости рынка"
				}
			};

			ListViewMenu.ItemsSource = menuItems;

			ListViewMenu.SelectedItem = menuItems[0];
			ListViewMenu.ItemSelected += async (sender, e) =>
			{
				if (e.SelectedItem == null)
				{
					return;
				}

				var id = (int) ((HomeMenuItem) e.SelectedItem).Id;
				await RootPage.NavigateFromMenu(id);
			};
		}
		#endregion

		#region Properties
		private MainPage RootPage => Application.Current.MainPage as MainPage;
		#endregion
	}
}
