using System.Collections.Generic;
using System.Threading.Tasks;
using gardener.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

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
                         await Call("84996371111");
                         break;
					case (int) MenuItemType.Purchase:
						// TODO: Переименовать или удалить и создать новую страницу.
						MenuPages.Add(id, new NavigationPage(new RentPage()));
						break;
					case (int) MenuItemType.EmployCall:
                        await Call("89153991269");
						break;
					case (int) MenuItemType.CallSecurity:
                        await Call("89261505109");
						break;
                    case (int)MenuItemType.Course:
                        MenuPages.Add(id, new NavigationPage(new CoursePage()));
                        break;
                    case (int)MenuItemType.Map:
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

        public async Task Call(string number)
        {
            try
            {
                await Task.Run(() =>
                {
                    PhoneDialer.Open(number);
                }
                );
            }

            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (System.Exception ex)
            {
                // Other error has occurred.  
            }
        }
        #endregion
    }
}
