using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using gardener.Models;
using gardener.ViewModels;
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
					Title = Properties.Strings.Rent
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Map,
					Title = Properties.Strings.Map
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Selling,
					Title = Properties.Strings.Selling
				},
				new HomeMenuItem
				{
					Id = MenuItemType.CallSecurity,
					Title = Properties.Strings.CallSecurity
				},
				new HomeMenuItem
				{
					Id = MenuItemType.EmployCall,
					Title = Properties.Strings.EmployCall
				},
				new HomeMenuItem
				{
					Id = MenuItemType.Course,
					Title = Properties.Strings.Course
				},
				new HomeMenuItem
				{
					Id = MenuItemType.News,
					Title = Properties.Strings.Marketnews
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

		private void Button_OnClicked(object sender, EventArgs e)
		{
			BaseViewModel.ChangeLanguage("ru-RU");
		}

		private void Button_OnClicked1(object sender, EventArgs e)
		{
			BaseViewModel.ChangeLanguage("vi-VN");
		}

		private void Button_OnClicked3(object sender, EventArgs e)
		{
			BaseViewModel.ChangeLanguage("zh-CN");
		}
	}
}
