using System;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppBuyPage : ContentPage
	{
		private FormAppBuyViewModel _viewModel;

		#region .ctor
		public FormAppBuyPage(Block block)
		{
			InitializeComponent();
			_viewModel = new FormAppBuyViewModel(block, new Uri("http://tc.itmit-studio.ru/api/bidForBuy"), PlaceNumber.Placeholder = Properties.Strings.Applicationformforleaseofpremises, OnFormSend);
			BindingContext = _viewModel;
        }
		#endregion

		private void OnFormSend(bool isSuccess)
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
