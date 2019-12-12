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
		}

		protected override async void ExecuteSendFormCommand()
		{
			IsBusy = true;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidService();

				if (string.IsNullOrEmpty(SelectedPlace.PlaceNumber) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention, $"{Strings.Place}, {Strings.Name}, {Strings.Number} {Strings.Notreading}", Strings.Ok);
					return;
				}

				try
				{
					if (await service.CreateBidForSale(new Bid(SelectedPlace.PlaceNumber, Name, PhoneNumber, _block, SelectedPlace.Row, _floor, Text)))
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
