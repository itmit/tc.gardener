using System;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.ListView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAppPage : ContentPage
	{
		private FormAppViewModel _viewModel;

		#region .ctor
		public FormAppPage(Block block)
		{
			InitializeComponent();

			_viewModel = new FormAppViewModel(block, Navigation);

			BindingContext = _viewModel;

			_viewModel.LoadData();

        }

		public FormAppPage(Block block, int floor)
		{
			InitializeComponent();
			_viewModel = new FormAppViewModel(block, floor, Navigation);

			BindingContext = _viewModel;

			_viewModel.LoadData();
		}
		#endregion

		private void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			if (_viewModel.IsBusy || _viewModel.PlaceCollection.Count == 0)
			{
				return;
			}

			if (e.Item is PlaceViewModel place)
			{
				if (place.Guid == _viewModel.PlaceCollection[_viewModel.PlaceCollection.Count - 1].Guid)
				{
					_viewModel.LoadData(100, _viewModel.PlaceCollection.Count + 100);
				}
			}

			
		}
	}
}
