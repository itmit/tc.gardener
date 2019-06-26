using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppBuyPage : ContentPage
	{
		#region .ctor
		public FormAppBuyPage(Block block)
		{
			InitializeComponent();

			BindingContext = new FormAppBuyViewModel(block);
		}
		#endregion
	}
}
