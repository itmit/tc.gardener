using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace gardener.Converters
{
	class PlaceStatusConverter : IValueConverter
	{
		private string _status;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string str)
			{
				_status = str;
				if (str.Equals("Забронировано"))
				{
					return Properties.Strings.Booked;
				}
			}

			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return _status;
		}
	}
}
