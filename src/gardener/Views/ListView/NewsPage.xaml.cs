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

		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			OpenRentPage();
			return true;
		}

		private async void OpenRentPage()
		{
			if (Application.Current.MainPage is MainPage main)
			{
				await main.NavigateFromMenu(1);
			}
		}
	}
}
