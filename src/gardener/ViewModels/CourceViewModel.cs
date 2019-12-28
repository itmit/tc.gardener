using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using gardener.Models;
using gardener.Services;

namespace gardener.ViewModels
{
	public class CourseViewModel : BaseViewModel
	{
		private readonly CourseDataStore _service;
		private Currency _selectedItem;
		private ObservableCollection<Currency> _items;
		private DateTime _dateTime;
		private string _coursesTableTitle;
		private string _ratesTitle;

		public CourseViewModel(CourseDataStore service)
		{
			_service = service;
			CoursesTableTitle = Properties.Strings.CoursesTableTitle;
			RatesTitle = Properties.Strings.RatesTitle;
		}

		public string RatesTitle
		{
			get => _ratesTitle;
			set => SetProperty(ref _ratesTitle, value);
		}

		public string CoursesTableTitle
		{
			get => _coursesTableTitle;
			set => SetProperty(ref _coursesTableTitle, value);
		}

		public async void UpdateCourse()
		{
			Course course = await _service.GetItemAsync();
			if (course != null)
			{
				Items = new ObservableCollection<Currency>
				{
					new Currency("USD", Math.Round(1 / course.Rates.USD, 3)),
					new Currency("EUR", Math.Round(1 / course.Rates.EUR, 3)),
					new Currency("JPY", Math.Round(1 / course.Rates.JPY, 3)),
					new Currency("GBP", Math.Round(1 / course.Rates.GBP, 3)),
					new Currency("CNY", Math.Round(1 / course.Rates.CNY, 3)),
					new Currency("UAH", Math.Round(1 / course.Rates.UAH, 3))
				};
				DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				_dateTime = dtDateTime.AddSeconds(course.Timestamp).ToLocalTime();
				
				OnPropertyChanged(nameof(DateTimeLastUpdate));
			}
		}

		public Currency SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				_selectedItem = null;
				OnPropertyChanged(nameof(SelectedItem));
			}
		}

		public ObservableCollection<Currency> Items
		{
			get => _items;
			set => SetProperty(ref _items, value);
		}

		public string DateTimeLastUpdate => _dateTime.ToString("dd.MM.yyyy HH:mm");

		protected override void OnLanguageChanged()
		{
            CoursesTableTitle = Properties.Strings.CoursesTableTitle;
            RatesTitle = Properties.Strings.RatesTitle;
        }
	}
}
