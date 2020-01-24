using System;
using gardener.Services;
using gardener.Views;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace gardener
{
	public partial class App : Application
	{
		#region .ctor
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
		#endregion

		#region Overrided
		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			try
			{
				DependencyService.Get<ISubscribeTopicFireBase>()?.SubscribeToAllTopic();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		#endregion
	}
}
