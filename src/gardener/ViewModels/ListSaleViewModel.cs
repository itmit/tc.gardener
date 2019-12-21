using System;
using System.ComponentModel;
using gardener.Models;
using gardener.Views;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ListSaleViewModel : BaseViewModel
	{
		private string _listOfAvailablePremises;
		private string _applicationForLeaseOfPremises;
		private string _applicationForLeaseOfInPremises;
		private string _infoButton;

		#region .ctor
		public ListSaleViewModel(INavigation navigation, Block block, int floor)
		{
			OpenPageCommand = new RelayCommand(obj =>
											   {
												   if (obj is Type type)
												   {
													   Page page;
													   switch (type.Name)
													   {
														   case nameof(FormAppPage):
															   page = new FormAppPage(block);
															   break;
														   case nameof(FormAppSalePage):
															   page = new FormAppSalePage(block, floor);
															   break;
														   case nameof(FormAppBuyPage):
															   page = new FormAppBuyPage(block, floor);
															   break;
														   case nameof(AssignmentRightUsePage):
															   page = new AssignmentRightUsePage(block, floor);
															   break;
														   default:
															   throw new ArgumentOutOfRangeException();
													   }
													   navigation.PushAsync(page);
												   }
											   },
											   param => param != null);

			SetStrings();
		}

		public void SetStrings()
		{
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
			get => _infoButton;
			set => SetProperty(ref _infoButton, value);
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
			SetStrings();
		}
	}
}
