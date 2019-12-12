using System;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppSalePage : ContentPage
	{
		#region .ctor
		public FormAppSalePage(Block block, int floor)
		{
			InitializeComponent();
			BindingContext = new FormAppSaleViewModel(block, floor, Navigation);
        }
		#endregion
	}
}
