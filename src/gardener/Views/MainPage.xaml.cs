using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using gardener.Models;
using gardener.Services;
using gardener.ViewModels;
using gardener.Views.ListView;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		#region Data
		#region Fields
		private readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        private MasterViewModel _mvm;
        #endregion
        #endregion

        #region .ctor
        public MainPage()
		{
			InitializeComponent();

			MasterBehavior = MasterBehavior.Popover;

			MenuPages.Add((int) MenuItemType.Rent, new NavigationPage(new RentSalePage()));
            _mvm = new MasterViewModel();
            Master.BindingContext = _mvm;
		}
		#endregion

		#region Public
		public void Call(string number)
		{
            Task.Run(() =>
            {
                DependencyService.Get<IPhoneCall>().MakeQuickCall(number);
            });
        }

		public async Task NavigateFromMenu(int id)
		{
			if (!MenuPages.ContainsKey(id))
			{
				switch (id)
				{
					case (int) MenuItemType.Rent:
						MenuPages.Add(id, new NavigationPage(new RentSalePage()));
						break;
					case (int) MenuItemType.Selling:
						Call("84996371111");
						return;
					case (int) MenuItemType.News:
						MenuPages.Add(id, new NavigationPage(new NewsPage()));
						break;
					case (int) MenuItemType.EmployCall:
						Call("89153991269");
						return;
					case (int) MenuItemType.CallSecurity:
						Call("89261505109");
						return;
					case (int) MenuItemType.Course:
						MenuPages.Add(id, new NavigationPage(new CoursePage()));
						break;
					case (int) MenuItemType.Map:
						MenuPages.Add(id, new NavigationPage(new MapPage()));
						break;
                    case (int) MenuItemType.SignIn:
                        MenuPages.Add(id, new NavigationPage(new LoginPage(_mvm)));
                        break;
				}
			}

			var newPage = MenuPages[id];

			if (newPage != null && Detail != newPage)
			{
				Detail = newPage;

				if (Device.RuntimePlatform == Device.Android)
				{
					await Task.Delay(100);
				}

				IsPresented = false;
			}
		}
		#endregion
	}
}
