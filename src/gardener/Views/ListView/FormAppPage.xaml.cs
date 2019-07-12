using System;
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

			viewModel.SetSerializedJsonDataAsync();
		}

		public FormAppPage(Block block, int floor)
		{
			InitializeComponent();

			var viewModel = new FormAppViewModel(block, floor);

			BindingContext = viewModel;

			viewModel.SetSerializedJsonDataAsync();
		}
		#endregion
	}
}
