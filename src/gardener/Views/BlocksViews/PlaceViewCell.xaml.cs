using Android.Content.Res;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.BlocksViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaceViewCell : ExtendedViewCell
	{
		#region .ctor
		public PlaceViewCell()
		{
			InitializeComponent();

			PlaceTitle.Text = Properties.Strings.Place;
			RowTitle.Text = Properties.Strings.Row;
			BaseViewModel.LanguageChangeEvent += OnLanguageChangeEvent;
        }
        #endregion


        private void OnLanguageChangeEvent()
		{
			PlaceTitle.Text = Properties.Strings.Place;
			RowTitle.Text = Properties.Strings.Row;
		}

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new ReservationPage());
        }
    }
}
