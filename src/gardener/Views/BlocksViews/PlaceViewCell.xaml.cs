using gardener.ViewModels;
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

            BindingContext = new PlaceViewModel();
        }
		#endregion

		private void OnLanguageChangeEvent()
		{
			PlaceTitle.Text = Properties.Strings.Place;
			RowTitle.Text = Properties.Strings.Row;
		}
        
        
	}
}
