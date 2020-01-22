using Firebase.CloudMessaging;
using gardener.iOS.Service;
using gardener.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SubscribeTopicFireBase))]
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
