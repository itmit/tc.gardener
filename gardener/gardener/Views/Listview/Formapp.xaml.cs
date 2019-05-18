using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.Rent
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Formapp : ContentPage
	{
		public Formapp ()
		{
			InitializeComponent ();

			BindingContext = new FormappViewModel();
		}
	}
}