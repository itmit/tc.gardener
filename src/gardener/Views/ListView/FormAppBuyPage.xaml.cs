using System;
using gardener.Models;
using gardener.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppBuyPage : ContentPage
	{
		private FormAppBuyViewModel _viewModel;

		#region .ctor
		public FormAppBuyPage(Block block, int floor)
		{
			InitializeComponent();
			_viewModel = new FormAppBuyViewModel(block, floor, Navigation);
			BindingContext = _viewModel;
		}
		#endregion
	}
}
