using System.ComponentModel;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ListSaleViewModel : BaseViewModel
	{
		private string _listOfAvailablePremises;
		private string _applicationForLeaseOfPremises;
		private string _applicationForLeaseOfInPremises;

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

			ListOfAvailablePremises = Properties.Strings.Listofavailablepremises;
			ApplicationForLeaseOfPremises = Properties.Strings.Applicationforleaseofpremises;
			ApplicationForLeaseOfInPremises = Properties.Strings.Applicationforleaseofinpremises;
		}

		public string ApplicationForLeaseOfInPremises
		{
			get => _applicationForLeaseOfInPremises;
			set => SetProperty(ref _applicationForLeaseOfInPremises, value);
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
			throw new System.NotImplementedException();
		}
	}
}
