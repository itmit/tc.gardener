using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		#region .ctor
		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
		}
		#endregion

		#region Properties
		public ICommand OpenWebCommand
		{
			get;
		}
		#endregion

		protected override void OnLanguageChanged()
		{
		}
	}
}
