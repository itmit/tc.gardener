using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormApp : ContentPage
	{
		#region .ctor
		public FormApp()
		{
			InitializeComponent();

			var viewModel = new FormAppViewModel();

			BindingContext = viewModel;

			viewModel.SetSerializedJsonData("http://tc.itmit-studio.ru/api/place");
		}
		#endregion
	}
}
