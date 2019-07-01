using System;
using gardener.Models;
using gardener.Services;
using gardener.Views.ListView;
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
		private readonly Block _block;
		private string _name;
		private string _phoneNumber;

		private string _placeNumber;
		#endregion
		#endregion

		#region .ctor
		public FormAppBuyViewModel(Block block, Uri url, string title)
		{
			Title = title;
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand(url);
											   },
											   x => true);
			_block = block;
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
		private async void ExecuteSendFormCommand(Uri url)
		{
			IsBusy = true;
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidForBuyDataStore(url);

				if (await service.AddItemAsync(new BidForBuy(PlaceNumber, Name, PhoneNumber, _block)))
				{
					// TODO: Дописать действия в случае успешной и отправки формы.
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
