using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RentsallePage : ContentPage
	{
		public RentsallePage ()
		{
			InitializeComponent ();

            BindingContext = new RentsalleViewModel(Navigation);
		}
	}
}