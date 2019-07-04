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

		private void UpdateCourse(object arg)
		{
			_viewModel.IsBusy = true;
			_viewModel.UpdateCourse();
			_viewModel.IsBusy = false;
		}
	}
}
