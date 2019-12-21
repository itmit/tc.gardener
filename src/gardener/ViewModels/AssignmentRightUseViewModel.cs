using System;
using gardener.Models;
using gardener.Views;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class AssignmentRightUseViewModel : BaseViewModel
	{
		private string _assignmentOfRights;
		private string _acquisitionOfRights;

		#region .ctor
		public AssignmentRightUseViewModel(INavigation navigation, Block block, int floor)
		{
			OpenPageCommand = new RelayCommand(obj =>
			{
				if (obj is string type)
				{
					Page page = new FeedbackPage(block, floor, type);
					
					navigation.PushAsync(page);
				}
			}, param => param != null);

			SetStrings();
		}

		public void SetStrings()
		{
			Title = Properties.Strings.FeedBackButton;
			AssignmentOfRights = Properties.Strings.AssignmentOfRights;
			AcquisitionOfRights = Properties.Strings.AcquisitionOfRights;
		}

		#endregion

		#region Properties
		public string AssignmentOfRights
		{
			get => _assignmentOfRights;
			set => SetProperty(ref _assignmentOfRights, value);
		}

		public string AcquisitionOfRights
		{
			get => _acquisitionOfRights;
			set => SetProperty(ref _acquisitionOfRights, value);
		}

		public RelayCommand OpenPageCommand
		{
			get;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			SetStrings();
		}
	}
}
