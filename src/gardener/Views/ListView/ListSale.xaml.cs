using System;
using gardener.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListSale : ContentPage
	{
		#region .ctor
		public ListSale(Block block)
		{
			InitializeComponent();
		}
		#endregion

		#region Private
		private void Button_buy(object sender, EventArgs e)
		{
			Navigation.PushAsync(new FormAppBuy());
		}

		private void Button_rent(object sender, EventArgs e)
		{
			Navigation.PushAsync(new FormApp());
		}

		private void Button_sale(object sender, EventArgs e)
		{
			Navigation.PushAsync(new FormAppSale());
		}
		#endregion
	}
}
