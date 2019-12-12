using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	class FeedbackViewModel : FormAppBuyViewModel
	{
		private readonly Block _block;
		private readonly int _floor;

		public FeedbackViewModel(Block block, int floor, INavigation navigation)
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
				var service = new FeedbackService();

				if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, $"{Properties.Strings.Name}, {Properties.Strings.Number}, {Properties.Strings.Text} {Properties.Strings.Notreading}", Properties.Strings.Ok);

					IsBusy = false;
					return;
				}

				try
				{
					if (await service.Send(PhoneNumber, SelectedPlace, _floor, _block, Text, Name))
					{
						await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, Properties.Strings.Theformwassuccessfullysent, Properties.Strings.Ok);
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, string.IsNullOrEmpty(service.LastError)
																										  ? Properties.Strings.Errorsubmittingform
																										  : service.LastError, Properties.Strings.Ok);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
			else
			{
				Title = Properties.Strings.WaitingForNetwork;
			}

			IsBusy = false;
		}
	}
}
