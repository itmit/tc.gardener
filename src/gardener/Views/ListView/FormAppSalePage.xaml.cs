using System;
using gardener.Models;
using gardener.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppSalePage : ContentPage
	{
		private FormAppSaleViewModel _vm;

		#region .ctor
		public FormAppSalePage(Block block, int floor)
		{
			InitializeComponent();
			_vm = new FormAppSaleViewModel(block, floor, Navigation);
			BindingContext = _vm;
		}
		#endregion

		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			if (_vm.IsShowedPop)
			{
				Navigation.PopPopupAsync();
				return false;
			}
			return base.OnBackButtonPressed();
		}
	}
}
