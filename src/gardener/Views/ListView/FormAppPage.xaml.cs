using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppPage : ContentPage
	{
		#region .ctor
		public FormAppPage(Block block)
		{
			InitializeComponent();

			var viewModel = new FormAppViewModel(block);

			BindingContext = viewModel;

			viewModel.SetSerializedJsonData("http://tc.itmit-studio.ru/api/places/" + block.Title + "/Свободен");
		}


		public FormAppPage(Block block, int floor)
		{
			InitializeComponent();

			var viewModel = new FormAppViewModel(block, floor);

			BindingContext = viewModel;

			viewModel.SetSerializedJsonData("http://tc.itmit-studio.ru/api/places/" + block.Title + "/Свободен");
		}
		#endregion
	}
}
