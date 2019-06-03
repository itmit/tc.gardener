using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppSalePage : ContentPage
	{
		#region .ctor
		public FormAppSalePage(Block block)
		{
			InitializeComponent();
			// TODO: Создать VM для Формы заявки продажи.
			var viewModel = new BaseViewModel
			{
				Title = "Форма заявки на аренду помещения"
			};
			BindingContext = viewModel;
		}
		#endregion
	}
}
