using System.Threading.Tasks;
using gardener.Services;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
		#region .ctor
		public NewsPage()
		{
			InitializeComponent();

			var vm = new NewsViewModel(Navigation, new NewsDataStore());
			BindingContext = vm;
			vm.IsBusy = true;
			Task.Run(() =>
			{
				vm.UpdateNews();
				vm.IsBusy = false;
			});
		}
		#endregion
	}
}
