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

			CoursesTableTitle = Properties.Strings.Course;
			RatesTitle = Properties.Strings.Course;
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
					new Currency("USD", 1 / course.Rates.USD),
					new Currency("EUR", 1 / course.Rates.EUR),
					new Currency("JPY", 1 / course.Rates.JPY),
					new Currency("GBP", 1 / course.Rates.GBP),
					new Currency("CNY", 1 / course.Rates.CNY),
					new Currency("UAH", 1 / course.Rates.UAH)
				};
				Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

				DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
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

		public string DateTimeLastUpdate 
			=> _dateTime.ToShortDateString() + " " + _dateTime.ToShortTimeString();

		protected override void OnLanguageChanged()
		{
			throw new NotImplementedException();
		}
	}
}
