using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.Listview
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Formapp : ContentPage
	{
		public Formapp ()
		{
			InitializeComponent ();

			var viewModel = new FormappViewModel();

			BindingContext = viewModel;

			viewModel.SetSerializedJsonData("http://tc.itmit-studio.ru/api/place");
		}
	}
}