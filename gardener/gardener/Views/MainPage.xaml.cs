using gardener.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Rent, new NavigationPage(new RentsallePage()));
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Rent:
                        MenuPages.Add(id, new NavigationPage(new RentsallePage()));
                        break;
                    case (int)MenuItemType.Selling:
                        MenuPages.Add(id, new NavigationPage(new SallePage()));
                        break;
                    case (int)MenuItemType.Rentsell:
                        MenuPages.Add(id, new NavigationPage(new RentPage()));
                        break;
                    case (int)MenuItemType.Challengemphous:
                        MenuPages.Add(id, new NavigationPage(new Challengemphous()));
                        break;
                    case (int)MenuItemType.Callsecurity:
                        MenuPages.Add(id, new NavigationPage(new Callsecurity()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}