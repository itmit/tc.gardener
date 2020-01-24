using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using gardener.Properties;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	class FeedbackViewModel : FormAppBuyViewModel
	{
		private readonly Block _block;
		private readonly int _floor;
		private string _type;

		public FeedbackViewModel(Block block, int floor, INavigation navigation, string type)
			: base(block, floor, navigation)
		{
			_type = type;
			_block = block;
			_floor = floor; 
			if (_type.Equals("assignment"))
			{
				Title = Strings.AssignmentOfRights;
			}

			if (_type.Equals("acquisition"))
			{
				Title = Strings.AcquisitionOfRights;
			}
		}

		protected override void OnLanguageChanged()
		{
			base.OnLanguageChanged();
			if (_type.Equals("assignment"))
			{
				Title = Strings.AssignmentOfRights;
			}

			if (_type.Equals("acquisition"))
			{
				Title = Strings.AcquisitionOfRights;
			}
		}

		protected override async void ExecuteSendFormCommand()
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new FeedbackService();

				SelectedPlace = new Place
				{
					PlaceNumber = Number,
					Row = Row
				};

				if (string.IsNullOrEmpty(SelectedPlace.PlaceNumber) 
					|| string.IsNullOrEmpty(SelectedPlace.Row) 
					|| string.IsNullOrEmpty(Name) 
					|| string.IsNullOrEmpty(Text) 
					|| string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention, $"{Strings.Place}, {Strings.Name}, {Strings.Number}, {Strings.Text} {Strings.Notreading}", Strings.Ok);

					IsBusy = false;
					return;
				}
				if (IsBusy)
				{
					return;
				}
				IsBusy = true;
				try
				{
					if (await service.Send(PhoneNumber, SelectedPlace, _floor, _block, Text, Name, _type))
					{
						PhoneNumber = "";
						Name = "";
						SelectedPlace = null;
						Text = "";
						PlaceName = Strings.SelectPlace;
						OldEntryNumber = "";
						OldEntryRow = "";

						if (_type.Equals("assignment"))
						{
							await Application.Current.MainPage.DisplayAlert(Strings.Attention, Strings.Theformwassuccessfullysent, Strings.Ok);
						}

						if (_type.Equals("acquisition"))
						{
							await Application.Current.MainPage.DisplayAlert(Strings.Attention, Strings.ApplicationToAcquireRightsIsAccepted, Strings.Ok);
						}
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert(Strings.Attention, string.IsNullOrEmpty(service.LastError)
																										  ? Strings.Errorsubmittingform
																										  : service.LastError, Strings.Ok);
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
