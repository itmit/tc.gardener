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
		private Action<bool> _onSendFormAction;
		private string _phoneTitle;
		private string _nameTitle;
		private string _placeTitle;
		private string _sendButtonText;
		private int _floor;
        private string _Plfeedback;
        #endregion
        #endregion

        #region .ctor
        public FeedbackViewModel(string title)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
			{
				ExecuteSendFormCommand();
			},
											   x => true);

			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			SendButtonText = Properties.Strings.SendButtonText;
			PhoneTitle = Properties.Strings.Phone;
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

		public FeedbackViewModel(Block block, int floor, string title, Action<bool> onSendFormAction)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
			{
				ExecuteSendFormCommand();
			},
											   x => true);
			_block = block;
			_onSendFormAction = onSendFormAction;
			_floor = floor;

			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			SendButtonText = Properties.Strings.SendButtonText;
			PhoneTitle = Properties.Strings.Phone;
		}
		#endregion

		public string GetLastError()
		{
			if (ErrorsList.Count > 1)
			{
				return ErrorsList[ErrorsList.Count - 1];
			}

			return "";
		}

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
					ShowResult(false);
					IsBusy = false;
					return;
				}

				if (await service.Send(PhoneNumber, Text, Name))
				{
					ShowResult(true);
				}
				else
				{
					if (service.ErrorsList.Count > 0)
					{
						foreach (var errorString in service.ErrorsList)
						{
							ErrorsList.Add(errorString);
						}
					}
					ShowResult(false);
				}
			}
			else
			{
				Title = Properties.Strings.WaitingForNetwork;
			}

			IsBusy = false;
		}

		public void ShowResult(bool isSuccess)
		{
			if (isSuccess)
			{
				Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, Properties.Strings.Theformwassuccessfullysent, Properties.Strings.Ok);
			}
			else
			{
				var error = GetLastError();
				if (error != "")
				{
					Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, error == "" ? Properties.Strings.Errorsubmittingform : GetLastError(), Properties.Strings.Ok);
				}
				else
				{
					Application.Current.MainPage.DisplayAlert(Properties.Strings.Attention, Properties.Strings.Place + ',' + Properties.Strings.Name + ',' + Properties.Strings.Number + ' ' + Properties.Strings.Notreading, Properties.Strings.Ok);
				}
			}
		}

		public List<string> ErrorsList
		{
			get;
		}
		#endregion


		protected override void OnLanguageChanged()
		{
          
        }
	}
}
