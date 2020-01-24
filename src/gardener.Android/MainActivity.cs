using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.Gms.Common;
using Android.Support.V13.View.Inputmethod;
using FFImageLoading.Forms.Platform;
using Firebase;

namespace gardener.Droid
{
	[Activity(Label = "Садовод онлайн",
		Icon = "@mipmap/l",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		internal static readonly string ChannelId = "my_notification_channel";
		internal static readonly int NotificationId = 100;

		private const string Tag = "GardenerMainActivity";
		#region Overrided
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		private void CreateNotificationChannel()
		{
			if (Build.VERSION.SdkInt < BuildVersionCodes.O)
			{
				// Notification channels are new in API 26 (and not a part of the
				// support library). There is no need to create a notification
				// channel on older versions of Android.
				return;
			}

			var channel = new NotificationChannel(ChannelId,
												  "FCM Notifications",
												  NotificationImportance.Default)
			{

				Description = "Firebase Cloud Messages appear in this channel"
			};

			var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
			notificationManager.CreateNotificationChannel(channel);
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			CachedImageRenderer.Init(true);

			base.OnCreate(savedInstanceState);

			if (Intent.Extras != null)
			{
				foreach (var key in Intent.Extras.KeySet())
				{
					var value = Intent.Extras.GetString(key);
					Log.Debug(Tag, "Key: {0} Value: {1}", key, value);
				}
			}

			CreateNotificationChannel();

			var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);

			Log.Info(Tag, $"IsGooglePlayServicesAvailable code is {resultCode}");

			Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

			Forms.Init(this, savedInstanceState);
			LoadApplication(new App());

			Platform.Init(this, savedInstanceState);
		}
		#endregion
	}
}
