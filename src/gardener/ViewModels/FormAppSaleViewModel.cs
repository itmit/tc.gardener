using System;
using System.Collections.Generic;
using System.ComponentModel;
using gardener.Models;
using gardener.Services;
using Plugin.Connectivity;

namespace gardener.ViewModels
{
	public class FormAppSaleViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly Block _block;
		private string _name;
		private string _phoneNumber;

		private string _placeNumber;
		private Action<bool> _onSendFormAction;
		#endregion
		#endregion

		#region .ctor
		public FormAppSaleViewModel(Block block, Uri url, string title)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand(url);
											   },
											   x => true);
			_block = block;
		}


		public FormAppSaleViewModel(Block block, Uri url, string title, Action<bool> onSendFormAction)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand(url);
											   },
											   x => true);
			_block = block;
			_onSendFormAction = onSendFormAction;
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

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

		public string PlaceNumber
		{
			get => _placeNumber;
			set => SetProperty(ref _placeNumber, value);
		}
		#endregion

		#region Private
		private async void ExecuteSendFormCommand(Uri url)
		{
			IsBusy = true;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidForSaleDataStore(url);

				if (await service.AddItemAsync(new BidForSale(PlaceNumber, Name, PhoneNumber, _block)))
				{
					_onSendFormAction(true);
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
					_onSendFormAction(false);
				}
			}
			else
			{
				Title = "Ожидание сети";
			}

			IsBusy = false;
		}

		public List<string> ErrorsList
		{
			get;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			throw new NotImplementedException();
		}
	}
}
