using System;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListSalePage : ContentPage
	{
        public ListSalePage()
        {
            InitializeComponent();
        }

        #region .ctor
        public ListSalePage(Block block, int floor)
		{
			InitializeComponent();

			BindingContext = new ListSaleViewModel(Navigation);

			RentButton.CommandParameter = new FormAppPage(block);
			SellButton.CommandParameter = new FormAppSalePage(block);
			BuyButton.CommandParameter = new FormAppBuyPage(block);
		}
		#endregion
	}
}
