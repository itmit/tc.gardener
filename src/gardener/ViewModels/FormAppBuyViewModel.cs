﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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
		private Action<bool> _callBack;
		private string _placeNumber;
		private string _phoneTitle;
		private string _nameTitle;
		private string _placeTitle;
		#endregion
		#endregion

		#region .ctor
		public FormAppBuyViewModel(Block block, Uri url, string title)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand(url);
											   },
											   x => true);
			_block = block;

			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
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

		public FormAppBuyViewModel(Block block, Uri url, string title, Action<bool> callBack)
		{
			ErrorsList = new List<string>();
			Title = title;
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand(url);
											   },
											   x => true);
			_block = block;
			_callBack = callBack;
		}
		#endregion

		public string GetLastError()
		{
			if (ErrorsList.Count > 1 || ErrorsList == null)
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

		public List<string> ErrorsList
		{
			get;
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
					_callBack(true);
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
					_callBack(false);
				}
			}
			else
			{
				Title = "Ожидание сети";
			}

			IsBusy = false;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			PlaceTitle = Properties.Strings.Place;
			NameTitle = Properties.Strings.Name;
			PhoneTitle = Properties.Strings.Phone;
		}
	}
}
