using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	class FeedbackViewModel : BaseViewModel
	{


		#region Data
		#region Fields
		private readonly Block _block;
		private string _name;
		private string _phoneNumber;

		private string _placeNumber;
		private string _phoneTitle;
		private string _nameTitle;
		private string _placeTitle;
		private string _sendButtonText;
		private int _floor;
        private string _Plfeedback;
		private string _textTitle;
		#endregion
        #endregion

        #region .ctor
        public FeedbackViewModel()
		{
			SendFormCommand = new RelayCommand(x =>
			{
				ExecuteSendFormCommand();
			},
											   x => true);
			SetStrings();
		}

		public string PhoneTitle
		{
			get => _phoneTitle;
			set => SetProperty(ref _phoneTitle, value);
		}

		public string NameTitle
		{
			get => _nameTitle;
			set => SetProperty(ref _nameTitle, value);
		}

		public string PlaceTitle
		{
			get => _placeTitle;
			set => SetProperty(ref _placeTitle, value);
		}

		public string TextTitle
		{
			get => _textTitle;
			set => SetProperty(ref _textTitle, value);
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

		public string SendButtonText
		{
			get => _sendButtonText;
			set => SetProperty(ref _sendButtonText, value);
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

        public string Plfeedback
        {
            get => _Plfeedback;
            set => SetProperty(ref _Plfeedback, value);
        }

        public string Text
		{
			get => _placeNumber;
			set => SetProperty(ref _placeNumber, value);
		}
		#endregion

		#region Private
		private async void ExecuteSendFormCommand()
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

				if (await service.Send(PhoneNumber, Text, Name))
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
			else
			{
				Title = Properties.Strings.WaitingForNetwork;
			}

			IsBusy = false;
		}

		#endregion

		private void SetStrings()
		{
			Title = Properties.Strings.Formfeedback;
			TextTitle = Properties.Strings.Text;
			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			SendButtonText = Properties.Strings.SendButtonText;
			PhoneTitle = Properties.Strings.Phone;
		}

		protected override void OnLanguageChanged()
		{
			SetStrings();
		}
	}
}
