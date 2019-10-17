namespace gardener.Services
{
	public interface INotificationService
	{
		void SendNotification(string title, string text, int id);

		void StopNotifications();
	}
}
