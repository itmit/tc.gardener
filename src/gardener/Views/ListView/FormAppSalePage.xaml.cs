using System;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppSalePage : ContentPage
	{

        private FormAppSaleViewModel _viewModel;

		#region .ctor
		public FormAppSalePage(Block block, int floor)
		{
			InitializeComponent();
			_viewModel = new FormAppSaleViewModel(block, floor, Properties.Strings.Applicationformforleaseofinpremises, OnSendForm);
			BindingContext = _viewModel;
        }
		#endregion

		private void OnSendForm(bool isSuccess)
		{
			if (isSuccess)
			{
				DisplayAlert(Properties.Strings.Attention, Properties.Strings.Theformwassuccessfullysent, Properties.Strings.Ok);
			}
			else
			{
				var error = _viewModel.GetLastError();
				DisplayAlert(Properties.Strings.Attention, error == "" ? Properties.Strings.Errorsubmittingform : _viewModel.GetLastError(), Properties.Strings.Ok);
			}
		}
	}
}
