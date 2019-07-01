using gardener.ViewModels;
using gardener.Views.ListView;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[0], 1));
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[2], 1));
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectFloorPage(BaseViewModel.Market.Blocks[1]));
        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {
           
        }

        private void ImageButton_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[5], 1));
        }

        private void ImageButton_Clicked_5(object sender, EventArgs e)
        {
            
        }

        private void ImageButton_Clicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[4], 1));
        }

        private void ImageButton_Clicked_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[3], 1));
        }
    }
}