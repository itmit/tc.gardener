using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;
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
						MenuPages.Add(id, new NavigationPage(new SalePage()));
						break;
					case (int) MenuItemType.Purchase:

						// TODO: Переименовать или удалить и создать новую страницу.
						MenuPages.Add(id, new NavigationPage(new RentPage()));
						break;
					case (int) MenuItemType.EmployCall:
						MenuPages.Add(id, new NavigationPage(new EmployCallPage()));
						break;
					case (int) MenuItemType.CallSecurity:
						MenuPages.Add(id, new NavigationPage(new CallSecurityPage()));
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
