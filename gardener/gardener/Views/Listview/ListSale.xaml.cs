using gardener.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.Rent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListSale : ContentPage
	{
		public ListSale (Place place)
		{
			InitializeComponent ();
		}

        private void Button_rent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Formapp());
        }

        private void Button_sale(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Formappsale());
        }

        private void Button_buy(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Formappbuy());
        }
    }
}