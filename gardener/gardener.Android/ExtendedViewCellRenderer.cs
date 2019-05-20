using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using gardener;
using gardener.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(ExtendedViewCellRenderer))]

namespace gardener.Droid
{
	internal class ExtendedViewCellRenderer : ViewCellRenderer
	{
		#region Data
		#region Fields
		private View _cellCore;
		private bool _selected;
		private Drawable _unselectedBackground;
		#endregion
		#endregion

		#region Overrided
		protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
		{
			_cellCore = base.GetCellCore(item, convertView, parent, context);

			_selected = false;
			_unselectedBackground = _cellCore.Background;

			return _cellCore;
		}

		protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnCellPropertyChanged(sender, args);

			if (args.PropertyName == "IsSelected")
			{
				_selected = !_selected;

				if (_selected)
				{
					if (sender is ExtendedViewCell extendedViewCell)
					{
						_cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
					}
				}
				else
				{
					_cellCore.SetBackground(_unselectedBackground);
				}
			}
		}
		#endregion
	}
}
