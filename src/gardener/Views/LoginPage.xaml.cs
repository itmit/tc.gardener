using gardener.Models;
using gardener.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(MasterViewModel mvm)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(mvm);
        }

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