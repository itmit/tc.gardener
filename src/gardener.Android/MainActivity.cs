using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;

namespace gardener.Droid
{
	[Activity(Label = "Садовод онлайн",
		Icon = "@mipmap/l",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		#region Overrided
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.notification_bg;
			Forms.Init(this, savedInstanceState);
			LoadApplication(new App());

			Platform.Init(this, savedInstanceState);
		}
		#endregion
	}
}
