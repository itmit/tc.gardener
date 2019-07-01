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
		public FormAppSalePage(Block block)
		{
			InitializeComponent();
			_viewModel = new FormAppSaleViewModel(block, new Uri("http://tc.itmit-studio.ru/api/bidForSale"), "Форма заявки на аренду помещения", OnSendForm);
			BindingContext = _viewModel;
		}
		#endregion

		private void OnSendForm(bool isSuccess)
		{
			if (isSuccess)
			{
				DisplayAlert("Внимание", "Форма успешно отправлена", "Ok");
			}
			else
			{
				var error = _viewModel.GetLastError();
				DisplayAlert("Внимание", error == "" ? "Ошибка отправки формы" : _viewModel.GetLastError(), "Ok");
			}
		}
	}
}
