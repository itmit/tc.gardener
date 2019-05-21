using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppBuy : ContentPage
	{
		#region .ctor
		public FormAppBuy(Block block)
		{
			InitializeComponent();

			// TODO: Создать VM для формы заявки покупки.
			var viewModel = new BaseViewModel
			{
				Title = "Форма заявки покупки"
			};
			BindingContext = viewModel;
		}
		#endregion
	}
}
