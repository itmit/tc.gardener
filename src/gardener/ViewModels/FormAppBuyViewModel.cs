using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using gardener.Models;
using gardener.Properties;
using gardener.Services;
using gardener.Views;
using gardener.Views.ListView;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

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
		private readonly int _floor;
		private string _name;
		private string _nameTitle;
		private readonly INavigation _navigation;
		private string _phoneNumber;
		private string _phoneTitle;
		private string _placeName;
		private ObservableCollection<Place> _places;
		private string _placeTitle;
		private string _row;
		private string _rowTitle;
		private string _sendButtonText;
		private Place _selectedPlace;
		private string _number;
		private string _textTitle;
		private string _text;
		#endregion
		#endregion

		#region .ctor
		public FormAppBuyViewModel(Block block, int floor, INavigation navigation)
		{
			SendFormCommand = new RelayCommand(x =>
											   {
												   ExecuteSendFormCommand();
											   },
											   x => true);
			_block = block;
			_floor = floor;
			if (block.Places == null)
			{
				LoadData();
			}
			else
			{
				if (block.Places?.Count == 0)
				{
					LoadData();
				}
			}

			_navigation = navigation;
			SetStrings();
		}
		#endregion

		#region Properties
		public RelayCommand SendFormCommand
		{
			get;
		}

		public string TextTitle
		{
			get => _textTitle;
			set => SetProperty(ref _textTitle, value);
		}

		public ICommand ClosePlacePopUpCommand =>
			new RelayCommand(obj =>
							 {
								 if (SelectedPlace != null)
								 {
									 PlaceName = $"Ряд {SelectedPlace.Row} Место {SelectedPlace.PlaceNumber}";
								 }

								 IsShowedPop = false;
								 _navigation.PopPopupAsync();
							 },
							 obj => true);

		public bool IsShowedPop
		{
			get;
			set;
		}

		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}

		public string NameTitle
		{
			get => _nameTitle;
			set => SetProperty(ref _nameTitle, value);
		}

		public ICommand OpenPlacePopUpCommand =>
			new RelayCommand(obj =>
							 {
								 IEnumerable<Place> places = _block.Places;

								 Places = places != null
											  ? new ObservableCollection<Place>(places) 
											  : new ObservableCollection<Place>();

								 IsShowedPop = true;
								 _navigation.PushPopupAsync(new SelectPlacePopUpPage(this));
							 },
							 obj => true);

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

		public string PhoneTitle
		{
			get => _phoneTitle;
			set => SetProperty(ref _phoneTitle, value);
		}

		public string PlaceName
		{
			get => _placeName;
			set => SetProperty(ref _placeName, value);
		}

		public string Number
		{
			get => _number;
			set
			{
				SetProperty(ref _number, value);
				UpdatePlaces();
			}
		}

		public string OldEntryNumber
		{
			get => _number;
			set => SetProperty(ref _number, value);
		}

		private void UpdatePlaces()
		{
			IEnumerable<Place> places = _block.Places;

			if (string.IsNullOrEmpty(_number))
			{
				if (!string.IsNullOrEmpty(Row))
				{
					places = _block.Places.Where(p => p.Row.Contains(Row));
				}
			}
			else
			{
				places = string.IsNullOrEmpty(Row)
							 ? _block.Places.Where(p => p.PlaceNumber.Contains(_number))
							 : _block.Places.Where(p => p.Row.Contains(Row) && p.PlaceNumber.Contains(_number));
			}

			Places = places != null ? new ObservableCollection<Place>(places) : new ObservableCollection<Place>();
		}

		public ObservableCollection<Place> Places
		{
			get => _places;
			set => SetProperty(ref _places, value);
		}

		public string PlaceTitle
		{
			get => _placeTitle;
			set => SetProperty(ref _placeTitle, value);
		}

		public string Row
		{
			get => _row;
			set
			{
				SetProperty(ref _row, value);
				UpdatePlaces();
			}
		}

		public string OldEntryRow
		{
			get => _row;
			set => SetProperty(ref _row, value);
		}

		public string Text
		{
			get => _text;
			set => SetProperty(ref _text, value);
		}

		public Place SelectedPlace
		{
			get => _selectedPlace;
			set => SetProperty(ref _selectedPlace, value);
		}

		public string RowTitle
		{
			get => _rowTitle;
			set => SetProperty(ref _rowTitle, value);
		}

		public string SendButtonText
		{
			get => _sendButtonText;
			set => SetProperty(ref _sendButtonText, value);
		}
		#endregion

		#region Public
		public async void LoadData(int limit = 100, int offset = 0)
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new PlaceService();
				try
				{
					_block.Places = new ObservableCollection<Place>(await service.GetPlaces(_block, _floor, limit, offset));
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}
		#endregion

		#region Overrided
		protected override void OnLanguageChanged()
		{
			SetStrings();
		}
		#endregion

		#region Private
		protected virtual async void ExecuteSendFormCommand()
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				var service = new BidService();
				if (string.IsNullOrEmpty(_number)
					|| string.IsNullOrEmpty(_row)
					|| string.IsNullOrEmpty(Name) 
					|| string.IsNullOrEmpty(Text) 
					|| string.IsNullOrEmpty(PhoneNumber))
				{
					await Application.Current.MainPage.DisplayAlert(Strings.Attention, $"{Strings.Place}, {Strings.Name}, {Strings.Number}, {Strings.Text} {Strings.Notreading}", Strings.Ok);

					return;
				}

				if (IsBusy)
				{
					return;
				}

				IsBusy = true;
				try
				{
					if (await service.CreateBidForBuy(new Bid(_number, Name, PhoneNumber, _block, _row, _floor, Text)))
					{
						PhoneNumber = "";
						Name = "";
						Text = "";
						SelectedPlace = null;
						PlaceName = Strings.SelectPlace;
						OldEntryNumber = "";
						OldEntryRow = "";
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

		private void SetStrings()
		{
			PlaceName = Strings.SelectPlace;
			TextTitle = Strings.Text;
			Title = Strings.Applicationforleaseofpremises;
			PlaceTitle = Strings.Place;
			NameTitle = Strings.Name;
			PhoneTitle = Strings.Phone;
			SendButtonText = Strings.SendButtonText;
			RowTitle = Strings.Row;
		}
		#endregion
	}
}
