using gardener.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage(Block block, int floor)
		{
			InitializeComponent();

			BindingContext = new FeedbackViewModel(block, floor, Navigation);
		}
	}
}