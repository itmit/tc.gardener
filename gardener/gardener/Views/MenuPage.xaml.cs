using gardener.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Rent, Title="Аренда" },
                new HomeMenuItem {Id = MenuItemType.Selling, Title="Продажа" },
                new HomeMenuItem {Id = MenuItemType.Rentsell, Title="Аренда" },
                new HomeMenuItem {Id = MenuItemType.Challengemphous, Title="Вызов сотрудника ЖКХ" },
                new HomeMenuItem {Id = MenuItemType.Callsecurity, Title="Вызов охраны" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}