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
		public FormAppBuyPage(Block block, int floor)
		{
			InitializeComponent();
			_viewModel = new FormAppBuyViewModel(block, floor, OnFormSend);
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
                if (error != "")
                {
                    DisplayAlert(Properties.Strings.Attention, error == "" ? Properties.Strings.Errorsubmittingform : _viewModel.GetLastError(), Properties.Strings.Ok);
                }
                else
                {
                    DisplayAlert(Properties.Strings.Attention, Properties.Strings.Place + ',' + Properties.Strings.Name + ',' + Properties.Strings.Number + ' ' + Properties.Strings.Notreading, Properties.Strings.Ok);
                }
			}
		}
	}
}
