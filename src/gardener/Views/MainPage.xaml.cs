using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using gardener.Models;
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
		#endregion
		#endregion

		#region .ctor
		public MainPage()
		{
			InitializeComponent();

			MasterBehavior = MasterBehavior.Popover;

			MenuPages.Add((int) MenuItemType.Rent, new NavigationPage(new RentSalePage()));
		}
		#endregion

		#region Public
		public async Task Call(string number)
		{
			try
			{
				PhoneDialer.Open(number);
			}
			catch (ArgumentNullException anEx)
			{
				// Number was null or white space
			}
			catch (FeatureNotSupportedException ex)
			{
				// Phone Dialer is not supported on this device.
			}
			catch (Exception ex)
			{
				// Other error has occurred.
			}
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
						await Call("84996371111");
						return;
					case (int) MenuItemType.News:
						MenuPages.Add(id, new NavigationPage(new NewsPage()));
						return;
					case (int) MenuItemType.EmployCall:
						await Call("89153991269");
						return;
					case (int) MenuItemType.CallSecurity:
						await Call("89261505109");
						return;
					case (int) MenuItemType.Course:
						MenuPages.Add(id, new NavigationPage(new CoursePage()));
						break;
					case (int) MenuItemType.Map:
						MenuPages.Add(id, new NavigationPage(new MapPage()));
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
