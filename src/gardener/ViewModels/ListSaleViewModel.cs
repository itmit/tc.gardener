using System.ComponentModel;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ListSaleViewModel : BaseViewModel
	{
		private string _listOfAvailablePremises;
		private string _applicationForLeaseOfPremises;
		private string _applicationForLeaseOfInPremises;
		private string infoButton;

		#region .ctor
		public ListSaleViewModel(INavigation navigation)
		{
			OpenPageCommand = new RelayCommand(obj =>
											   {
												   if (obj is Page page)
												   {
													   navigation.PushAsync(page);
												   }
											   },
											   param => param != null);

			Title = Properties.Strings.ListSalePageTitle;
			InfoButton = Properties.Strings.FeedBackButton;
			ListOfAvailablePremises = Properties.Strings.Listofavailablepremises;
			ApplicationForLeaseOfPremises = Properties.Strings.Applicationforleaseofpremises;
			ApplicationForLeaseOfInPremises = Properties.Strings.Applicationforleaseofinpremises;
		}

		public string ApplicationForLeaseOfInPremises
		{
			get => _applicationForLeaseOfInPremises;
			set => SetProperty(ref _applicationForLeaseOfInPremises, value);
		}

		public string InfoButton
		{
			get => infoButton;
			set => SetProperty(ref infoButton, value);
		}

		public string ApplicationForLeaseOfPremises
		{
			get => _applicationForLeaseOfPremises;
			set => SetProperty(ref _applicationForLeaseOfPremises, value);
		}

		public string ListOfAvailablePremises
		{
			get => _listOfAvailablePremises;
			set => SetProperty(ref _listOfAvailablePremises, value);
		}
		#endregion

		#region Properties

		public RelayCommand OpenPageCommand
		{
			get;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			Title = Properties.Strings.ListSalePageTitle;
			InfoButton = Properties.Strings.FeedBackButton;
			ListOfAvailablePremises = Properties.Strings.Listofavailablepremises;
			ApplicationForLeaseOfPremises = Properties.Strings.Applicationforleaseofpremises;
			ApplicationForLeaseOfInPremises = Properties.Strings.Applicationforleaseofinpremises;
		}
	}
}
