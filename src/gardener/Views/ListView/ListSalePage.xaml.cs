using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListSalePage : ContentPage
	{
		#region .ctor
		public ListSalePage()
		{
			InitializeComponent();
		}

		public ListSalePage(Block block, int floor)
		{
			InitializeComponent();

			BindingContext = new ListSaleViewModel(Navigation, block, floor);

			RentButton.CommandParameter = typeof(FormAppPage);
			SellButton.CommandParameter = typeof(FormAppSalePage);
			BuyButton.CommandParameter = typeof(FormAppBuyPage);
			InfoButton.CommandParameter = typeof(FeedbackPage);
		}
		#endregion
	}
}
