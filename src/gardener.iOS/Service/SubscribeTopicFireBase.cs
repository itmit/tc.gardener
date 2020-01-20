using Firebase.CloudMessaging;
using gardener.Services;

namespace gardener.iOS.Service
{
	public class SubscribeTopicFireBase : ISubscribeTopicFireBase
	{
		private const string TopicName = "AdminNotification";

		public void Subscribe()
		{
			Messaging.SharedInstance.Subscribe(TopicName);
		}

		public void Unsubscribe()
		{
			Messaging.SharedInstance.Unsubscribe(TopicName);
		}
	}
}
