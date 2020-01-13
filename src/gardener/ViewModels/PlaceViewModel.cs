using System;
using System.Threading;
using gardener.Models;

namespace gardener.ViewModels
{
	public class PlaceViewModel : BaseViewModel
	{
		private Place _place;
		private Timer _timer;
		private string _time;
		private DateTime? _dateTime;
		private bool _isStatusVisible;
		private string _expiresIn;

		public Guid Guid
		{
			get;
		} = Guid.NewGuid();

		public bool IsStatusVisible
		{
			get => _isStatusVisible;
			set => SetProperty(ref _isStatusVisible, value);
		}

		public PlaceViewModel(Place place, DateTime? serverDateTime)
		{
			ExpiresIn = Properties.Strings.ExpiresIn;
			IsStatusVisible = place.Status.Equals("Забронировано");
			TimeSpan timeValue;
			Place = place;
			if (serverDateTime == null || Place.ReservationDate == null)
			{
				return;
			}

			DateTime = new DateTime(Place.ReservationDate.Value.Ticks);
			timeValue = Place.ReservationDate.Value - serverDateTime.Value;

			DateTime = DateTime.Value.AddHours(3);
			_timer = new Timer(state =>
			{
				if (timeValue.Ticks <= 0 || _timer == null)
				{
					return;
				}

				timeValue = timeValue - TimeSpan.FromSeconds(1);
				Time = timeValue.ToString();
			}, null, 0, 1000);
		}

		public DateTime? DateTime
		{
			get => _dateTime;
			set => SetProperty(ref _dateTime, value);
		}

		public Place Place
		{
			get => _place;
			set => SetProperty(ref _place, value);
		}

		public string Time
		{
			get => _time;
			set => SetProperty(ref _time, value);
		}

		protected override void OnLanguageChanged()
		{
			ExpiresIn = Properties.Strings.ExpiresIn;
		}

		public string ExpiresIn
		{
			get => _expiresIn;
			set => SetProperty(ref _expiresIn, value);
		}
	}
}
