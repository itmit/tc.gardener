using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views.BlocksViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FloorViewCell : ExtendedViewCell
	{
		#region .ctor
		public FloorViewCell()
		{
			InitializeComponent();


			Binding labelBinding = new Binding
			{
				Path = "Value",
				StringFormat = "{0} " + Properties.Strings.Floor
			};

			Label.SetBinding(Label.TextProperty, labelBinding);

			BaseViewModel.LanguageChangeEvent += OnLanguageChangeEvent;
		}
		#endregion

		private void OnLanguageChangeEvent()
		{
			Binding labelBinding = new Binding
			{
				Path = "Value",
				StringFormat = "{0} " + Properties.Strings.Floor
			};

			Label.SetBinding(Label.TextProperty, labelBinding);
		}
	}
}
