using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RentPage : ContentPage
	{
		#region .ctor
		public RentPage()
		{
			InitializeComponent();

			//BindingContext = new RentSaleViewModel(Navigation);
		}
		#endregion
	}
}
