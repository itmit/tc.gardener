using gardener.ViewModels;
using gardener.Views.ListView;
using System;
using System.Globalization;
using System.Threading;
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

			BaseViewModel.LanguageChangeEvent += OnLanguageChangeEvent;
			SetImages();
		}

		private void OnLanguageChangeEvent()
		{
			SetImages();
		}

		private void SetImages()
		{
			if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
			{
				Tc2.Source = "tc2.png";
				Tc3.Source = "tc3.png";
				Tc4.Source = "tc4.png";
				Tc5.Source = "tc5.png";
				Tc6.Source = "tc6.png";
				Tc7.Source = "tc7.png";
				Tc9.Source = "tc9.png";
			}
			else
			{
				Tc2.Source = "entc2.png";
				Tc3.Source = "entc3.png";
				Tc4.Source = "entc4.png";
				Tc5.Source = "entc5.png";
				Tc6.Source = "entc6.png";
				Tc7.Source = "entc7.png";
				Tc9.Source = "entc9.png";
			}
		}

		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			OpenRentPage();
			return true;
		}

		private async void OpenRentPage()
		{
			if (Application.Current.MainPage is MainPage main)
			{
				await main.NavigateFromMenu(1);
			}
		}

		private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[0], 1));
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[3], 1));
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectFloorPage(BaseViewModel.Market.Blocks[1]));
        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectFloorPage(BaseViewModel.Market.Blocks[2]));
        }

        private void ImageButton_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[6], 1));
        }

        private void ImageButton_Clicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[5], 1));
        }

        private void ImageButton_Clicked_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSalePage(BaseViewModel.Market.Blocks[4], 1));
        }
    }
}