﻿using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;

namespace gardener.Droid.Services
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class FireBaseService : FirebaseMessagingService
	{
		private const string Tag = "GardenerFireBaseService";

		public override void OnMessageReceived(RemoteMessage message)
		{
			Log.Debug(Tag, "From: " + message.From);

			var body = message.GetNotification().Body;
			Log.Debug(Tag, "Notification Message Body: " + body);
			SendNotification(body, message.Data);
		}

		void SendNotification(string messageBody, IDictionary<string, string> data)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			foreach (var key in data.Keys)
			{
				intent.PutExtra(key, data[key]);
			}

			var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NotificationId, intent, PendingIntentFlags.OneShot);

			var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.ChannelId)
									  .SetSmallIcon(Resource.Drawable.pict_1)
									  .SetContentTitle("Внимание")
									  .SetContentText(messageBody)
									  .SetAutoCancel(true)
									  .SetContentIntent(pendingIntent);

			var notificationManager = NotificationManagerCompat.From(this);
			notificationManager.Notify(MainActivity.NotificationId, notificationBuilder.Build());
		}

		public override void OnNewToken(string p0)
		{
			base.OnNewToken(p0);
			Log.Debug(Tag, "Refreshed token: " + p0);
			SendRegistrationToServer(p0);
		}

		void SendRegistrationToServer(string token)
		{
			// Add custom implementation, as needed.
		}
	}
}
