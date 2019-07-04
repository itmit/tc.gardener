using System;
using System.Collections.ObjectModel;
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

		public CourseViewModel(CourseDataStore service)
		{
			_service = service;
		}

		public async void UpdateCourse()
		{
			Course course = await _service.GetItemAsync();
			if (course != null)
			{
				Items = new ObservableCollection<Currency>
				{
					course.Values.USD,
					course.Values.EUR,
					course.Values.JPY,
					course.Values.GBP,
					course.Values.CNY,
					course.Values.UAH
				};
				Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
				_dateTime = DateTime.Parse(course.Timestamp);
				//_dateTime = new DateTime(_dateTime.Year, _dateTime.Month, _dateTime.Day, _dateTime.Hour + 3, _dateTime.Minute, _dateTime.Second);
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
	}
}
