using System;
using System.Globalization;
using Xamarin.Forms;

namespace gardener.Converters
{
	/// <summary>
	/// Представляет механизм для перевода активности в цвет обозначающий активность.
	/// </summary>
	public class BoolActiveToColorConverter : IValueConverter
	{
		#region Properties
		/// <summary>
		/// Возвращает или устанавливает цвет активного блока.
		/// </summary>
		public Color ActiveColor
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает цвет не активного блока.
		/// </summary>
		public Color NoActiveColor
		{
			get;
			set;
		}
		#endregion

		#region IValueConverter members
		/// <param name="value">The value to convert.</param>
		/// <param name="targetType">The type to which to convert the value.</param>
		/// <param name="parameter">A parameter to use during the conversion.</param>
		/// <param name="culture">The culture to use during the conversion.</param>
		/// <summary>
		/// Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using
		/// <paramref name="parameter" /> and <paramref name="culture" />.
		/// </summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool) value ? ActiveColor : NoActiveColor;

		/// <param name="value">The value to convert.</param>
		/// <param name="targetType">The type to which to convert the value.</param>
		/// <param name="parameter">A parameter to use during the conversion.</param>
		/// <param name="culture">The culture to use during the conversion.</param>
		/// <summary>
		/// Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using
		/// <paramref name="parameter" /> and <paramref name="culture" />.
		/// </summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Color) value == ActiveColor;
		#endregion
	}
}
