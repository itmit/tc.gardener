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
			_viewModel = new FormAppBuyViewModel(block, new Uri("http://tc.itmit-studio.ru/api/bidForBuy"), "Форма заявки на сдачу в аренду помещения", OnFormSend);
			BindingContext = _viewModel;
		}
		#endregion

		private void OnFormSend(bool isSuccess)
		{
			if (isSuccess)
			{
				DisplayAlert("Внимание", "Форма успешно отправлена", "Ok");
			}
			else
			{
				DisplayAlert("Внимание", _viewModel.GetLastError(), "Ok");
			}
		}
	}
}
