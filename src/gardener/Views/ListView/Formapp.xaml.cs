using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormApp : ContentPage
	{
		#region .ctor
		public FormApp(Block block)
		{
			InitializeComponent();

			var viewModel = new FormAppViewModel(block);

			BindingContext = viewModel;

			viewModel.SetSerializedJsonData("http://tc.itmit-studio.ru/api/places/" + block.Title + "/Свободен");
		}
		#endregion
	}
}
