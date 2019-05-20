using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RentSalePage : ContentPage
	{
		#region .ctor
		public RentSalePage()
		{
			InitializeComponent();

			BindingContext = new RentSaleViewModel(Navigation);
		}
		#endregion
	}
}
