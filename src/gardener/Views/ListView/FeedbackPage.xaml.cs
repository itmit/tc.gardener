using gardener.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.Models;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedbackPage : ContentPage
	{
		private FeedbackViewModel _viewModel;

		public FeedbackPage(Block block, int floor, string type)
		{
			InitializeComponent();

			_viewModel = new FeedbackViewModel(block, floor, Navigation, type);
			BindingContext = _viewModel;
		}


		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			if (_viewModel.IsShowedPop)
			{
				try
				{
					Navigation.PopPopupAsync();
					return false;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
			return base.OnBackButtonPressed();
		}
	}
}