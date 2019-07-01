using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectFloorPage : ContentPage
	{
		#region .ctor
		public SelectFloorPage(Block block)
		{
			InitializeComponent();

			BindingContext = new SelectFloorViewModel(block, Navigation);
		}
		#endregion
	}
}
