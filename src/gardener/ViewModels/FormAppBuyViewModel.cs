using gardener.Models;
using gardener.Properties;
using gardener.Services;
using gardener.Views.ListView;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	/// <summary>
	/// Представляет ViewModel для <see cref="FormAppBuyPage" />
	/// </summary>
	public class FormAppBuyViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly Block _block;
		private readonly int _floor;
		private string _name;
		private string _nameTitle;
		private string _phoneNumber;
		private string _phoneTitle;
		private string _placeNumber;
		private string _placeTitle;
		private string _row;
		private string _rowTitle;
		private string _sendButtonText;
		#endregion
		#endregion

		#region .ctor
		public FormAppBuyViewModel(Block block, int floor)
		{
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand();
											   },
											   x => true);
			_block = block;
			_floor = floor;

			SetStrings();
		}
		#endregion

		#region Properties
		public RelayCommand SendFormCommand
		{
			get;
		}

		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}

		public string NameTitle
		{
			get => _nameTitle;
			set => SetProperty(ref _nameTitle, value);
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

		public string PhoneTitle
		{
			get => _phoneTitle;
			set => SetProperty(ref _phoneTitle, value);
		}

		public string PlaceNumber
		{
			get => _placeNumber;
			set => SetProperty(ref _placeNumber, value);
		}

		public string PlaceTitle
		{
			get => _placeTitle;
			set => SetProperty(ref _placeTitle, value);
		}

		public string Row
		{
			get => _row;
			set => SetProperty(ref _row, value);
		}

		public string RowTitle
		{
			get => _rowTitle;
			set => SetProperty(ref _rowTitle, value);
		}

		public string SendButtonText
		{
			get => _sendButtonText;
			set => SetProperty(ref _sendButtonText, value);
		}
		#endregion

		#region Overrided
		protected override void OnLanguageChanged()
		{
			SetStrings();
		}
		#endregion

		#region Private
		private async void ExecuteSendFormCommand()
		{
			IsBusy = true;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidService();

				if (string.IsNullOrEmpty(PlaceTitle) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention,
																	$"{Strings.Place}, {Strings.Name}, {Strings.Number} {Strings.Notreading}",
																	Strings.Ok);
					return;
				}

				if (await service.CreateBid(new BidForBuy(PlaceNumber, Name, PhoneNumber, _block, Row, _floor)))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention, Strings.Theformwassuccessfullysent, Strings.Ok);
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention,
																	string.IsNullOrEmpty(service.LastError) ? Strings.Errorsubmittingform : service.LastError,
																	Strings.Ok);
				}
				
			}
			else
			{
				Title = Strings.WaitingForNetwork;
			}

			IsBusy = false;
		}

		private void SetStrings()
		{
			Title = Strings.Applicationformforleaseofpremises;
			PlaceTitle = Strings.Place;
			NameTitle = Strings.Name;
			PhoneTitle = Strings.Phone;
			SendButtonText = Strings.SendButtonText;
			RowTitle = Strings.Row;
		}
		#endregion
	}
}
