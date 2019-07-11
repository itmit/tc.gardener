using System.ComponentModel;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class ListSaleViewModel : BaseViewModel
	{
		#region .ctor
		public ListSaleViewModel(INavigation navigation)
		{
			OpenPageCommand = new RelayCommand(obj =>
											   {
												   if (obj is Page page)
												   {
													   navigation.PushAsync(page);
												   }
											   },
											   param => param != null);
		}
		#endregion

		#region Properties
		public RelayCommand OpenPageCommand
		{
			get;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			throw new System.NotImplementedException();
		}
	}
}
