using Android.App;
using Android.OS;
using Android.Support.V4.App;
using gardener.Droid;
using gardener.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationServiceAndroid))]
namespace gardener.Droid
{
    public class NotificationServiceAndroid : INotificationService
	{
		private const string NotificationChannelId = "GardenerNotificationChannel";

		private readonly NotificationManager _notificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.NotificationService);
		private readonly NotificationCompat.Builder _notificationBuilder = new NotificationCompat.Builder(Application.Context, NotificationChannelId);

		public NotificationServiceAndroid()
		{
			if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
			{
				NotificationChannel notificationChannel = new NotificationChannel(NotificationChannelId, "General", NotificationImportance.Default)
				{
					Description = "Messages Channel"
				};

				// Configure the notification channel.
				notificationChannel.EnableLights(true);
				notificationChannel.LightColor = 0;
				notificationChannel.SetVibrationPattern(new long[] { 0, 1000, 500, 1000 });
				notificationChannel.EnableVibration(true);
				_notificationManager.CreateNotificationChannel(notificationChannel);
			}
		}

		public void SendNotification(string title, string text, int id)
		{
			_notificationBuilder.SetAutoCancel(true)
				.SetDefaults(Notification.ColorDefault)
				.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
				.SetOngoing(true)
				.SetContentTitle(title)
				.SetContentText(text)
				.SetContentInfo("Info");

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				_notificationBuilder.SetSmallIcon(Resource.Drawable.notifications);
				_notificationBuilder.SetColor(Resource.Color.primary_material_dark);
				_notificationBuilder.SetCategory(Notification.CategoryMessage);
			}
			else
			{
				_notificationBuilder.SetSmallIcon(Resource.Drawable.notifications);
			}

			_notificationManager.Notify(1, _notificationBuilder.Build());
		}

		public void StopNotifications()
		{
			_notificationManager.CancelAll();
		}
	}
}
