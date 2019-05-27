using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ListSaleViewModel : BaseViewModel
	{
		public ListSaleViewModel(INavigation navigation)
		{
			OpenPageCommand = new RelayCommand(obj =>
			{
				if (obj is Page page)
				{
					navigation.PushAsync(page);
				}
			}, param => param != null);
		}

		public RelayCommand OpenPageCommand
		{
			get;
		}
	}
}
