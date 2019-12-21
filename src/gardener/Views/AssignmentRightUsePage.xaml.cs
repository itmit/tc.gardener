using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssignmentRightUsePage : ContentPage
	{
		public AssignmentRightUsePage(Block block, int floor)
		{
			InitializeComponent();
			BindingContext = new AssignmentRightUseViewModel(Navigation, block, floor);

			AcquisitionOfRights.CommandParameter = "acquisition";
			AssignmentOfRights.CommandParameter = "assignment";
		}
	}
}