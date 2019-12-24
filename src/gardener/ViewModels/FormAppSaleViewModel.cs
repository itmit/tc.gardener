using System;
using System.Collections.Generic;
using gardener.Models;
using gardener.Properties;
using gardener.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class FormAppSaleViewModel : FormAppBuyViewModel
	{
		private readonly Block _block;
		private readonly int _floor;

		public FormAppSaleViewModel(Block block, int floor, INavigation navigation)
			: base(block, floor, navigation)
		{
			_block = block;
			_floor = floor;
			Title = Strings.Applicationforleaseofinpremises;
		}

		protected override void OnLanguageChanged()
		{
			base.OnLanguageChanged();
			Title = Strings.Applicationforleaseofinpremises;
		}

		protected override async void ExecuteSendFormCommand()
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidService();
				if (string.IsNullOrEmpty(Number)
					|| string.IsNullOrEmpty(Row)
					|| string.IsNullOrEmpty(Name) 
					|| string.IsNullOrEmpty(Text) 
					|| string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention, $"{Strings.Place}, {Strings.Name}, {Strings.Number}, {Strings.Text} {Strings.Notreading}", Strings.Ok);

					return;
				}
				IsBusy = true;
				try
				{
					if (await service.CreateBidForSale(new Bid(Number, Name, PhoneNumber, _block, Row, _floor, Text)))
					{
						PhoneNumber = "";
						Name = "";
						SelectedPlace = null;
						Text = "";
						PlaceName = Strings.SelectPlace;
						OldEntryNumber = "";
						OldEntryRow = "";
						await Application.Current.MainPage.DisplayAlert(Strings.Attention, Strings.ApplicationForSurrenderIsAccepted, Strings.Ok);
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert(Strings.Attention,
																		string.IsNullOrEmpty(service.LastError) ? Strings.Errorsubmittingform : service.LastError,
																		Strings.Ok);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
			else
			{
				Title = Strings.WaitingForNetwork;
			}

			IsBusy = false;
		}
	}
}
