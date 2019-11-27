using System;
using System.Collections.Generic;
using gardener.Models;
using gardener.Properties;
using gardener.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class FormAppSaleViewModel : BaseViewModel
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
		public FormAppSaleViewModel(Block block, int floor)
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

		private void SetStrings()
		{
			Title = Strings.Applicationformforleaseofinpremises;
			PlaceTitle = Strings.Place;
			NameTitle = Strings.Name;
			SendButtonText = Strings.SendButtonText;
			PhoneTitle = Strings.Phone;
			RowTitle = Strings.Row;
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

				if (await service.CreateBid(new BidForSale(PlaceNumber, Name, PhoneNumber, _block, Row, _floor)))
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
		#endregion
	}
}
