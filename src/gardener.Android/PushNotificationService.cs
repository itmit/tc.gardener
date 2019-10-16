using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace gardener.Droid
{
	class PushNotificationService : Service
	{
		public PushNotificationService()
		{
			CreateNotificationChannel();
		}

		public override IBinder OnBind(Intent intent) => null;

		private void CreateNotificationChannel()
		{
			if (Build.VERSION.SdkInt < BuildVersionCodes.O)
			{
				// Notification channels are new in API 26 (and not a part of the
				// support library). There is no need to create a notification
				// channel on older versions of Android.
				return;
			}

			var name = AppInfo.Name;
			var channel = new NotificationChannel(AppInfo.Name, name, NotificationImportance.Default)
			{
				Description = "News channel"
			};

			var notificationManager = (NotificationManager)GetSystemService(NotificationService);
			notificationManager.CreateNotificationChannel(channel);
		}

		public void PushNotification(string title, string text)
		{
			NotificationCompat.Builder builder = new NotificationCompat.Builder(this, AppInfo.Name)
				.SetContentTitle(title)
				.SetContentText(text);

			// Build the notification:
			Notification notification = builder.Build();

			// Get the notification manager:
			NotificationManager notificationManager =
				GetSystemService(Context.NotificationService) as NotificationManager;

			// Publish the notification:
			const int notificationId = 0;
			notificationManager.Notify(notificationId, notification);
		}
	}
}