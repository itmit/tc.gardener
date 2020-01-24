using System.Threading;
using System.Threading.Tasks;
using gardener.Services;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoursePage : ContentPage
	{
		private Timer _timer;
		private CourseViewModel _viewModel;

		#region .ctor
		public CoursePage()
		{
            InitializeComponent();

			_viewModel = new CourseViewModel(new CourseDataStore());
			BindingContext = _viewModel;

			_timer = new Timer(UpdateCourse, null, 0, 5000);
		}
		#endregion

		/// <summary>Application developers can override this method to provide behavior when the back button is pressed.</summary>
		/// <returns>To be added.</returns>
		/// <remarks>To be added.</remarks>
		protected override bool OnBackButtonPressed()
		{
			OpenRentPage();
			return true;
		}

		private async void OpenRentPage()
		{
			if (Application.Current.MainPage is MainPage main)
			{
				await main.NavigateFromMenu(1);
			}
		}

		private void UpdateCourse(object arg)
		{
			_viewModel.IsBusy = true;
			_viewModel.UpdateCourse();
			_viewModel.IsBusy = false;
		}
	}
}
