using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public NewsPage()
		{
			InitializeComponent();

			var vm = new NewsViewModel(Navigation, new NewsDataStore());
			BindingContext = vm;

			vm.UpdateNews();
		}
	}
}