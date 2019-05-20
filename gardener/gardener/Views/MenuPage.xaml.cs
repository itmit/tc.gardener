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
					Title = "Аренда"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Selling,
					Title = "Продажа"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Rentsell,
					Title = "Аренда"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Challengemphous,
					Title = "Вызов сотрудника ЖКХ"
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Callsecurity,
					Title = "Вызов охраны"
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
