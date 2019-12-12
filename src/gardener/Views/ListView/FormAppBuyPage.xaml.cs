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

		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			if (_viewModel.IsShowedPop)
			{
				Navigation.PopPopupAsync();
				return false;
			}
			return base.OnBackButtonPressed();
		}
	}
}
