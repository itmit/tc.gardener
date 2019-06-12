using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using gardener.Models;
using gardener.Services;
using gardener.Views.ListView;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace gardener.ViewModels
{
	/// <summary>
	/// Представляет ViewModel для <see cref="FormAppBuyPage" />
	/// </summary>
	public class FormAppBuyViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private string _name;
		private string _phoneNumber;

		private string _placeNumber;
		#endregion
		#endregion

		#region .ctor
		public FormAppBuyViewModel()
		{
			Title = "Форма заявки на сдачу в аренду помещения";
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand();
											   },
											   x => true);
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
		private async void ExecuteSendFormCommand()
		{
			IsBusy = true;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidForSaleDataStore("http://tc.itmit-studio.ru/api/bid-for-sale");

				if (await service.AddItemAsync(new BidForSale(PlaceNumber, Name, PhoneNumber)))
				{
					// TODO: Дописать действия в случае успешной и отправки формы.
				}
				else
				{
					// TODO: Дописать действия в случае отправки формы с ошибкой.
				}
			}
			else
			{
				Title = "Ожидание сети";
			}

			IsBusy = false;
		}
		#endregion
	}
}
