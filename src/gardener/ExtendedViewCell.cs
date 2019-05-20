using Xamarin.Forms;

namespace gardener
{
	public class ExtendedViewCell : ViewCell
	{
		#region Data
		#region Static
		public static readonly BindableProperty SelectedBackgroundColorProperty =
			BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(ExtendedViewCell), Color.Default);
		#endregion
		#endregion

		#region Properties
		public Color SelectedBackgroundColor
		{
			get => (Color) GetValue(SelectedBackgroundColorProperty);
			set => SetValue(SelectedBackgroundColorProperty, value);
		}
		#endregion
	}
}
