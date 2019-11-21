using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Firebase.Messaging;
using gardener.Droid.Services;
using gardener.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SubscribeTopicFireBaseDroid))]
namespace gardener.Droid.Services
{
	public class SubscribeTopicFireBaseDroid : ISubscribeTopicFireBase
	{
		private const string TopicName = "AdminNotification";

		public async void Subscribe()
		{
			// Subscribe the devices corresponding to the registration tokens to the
			// topic
			var response = await FirebaseMessaging.Instance.SubscribeToTopic(TopicName);
		}

		public async void Unsubscribe()
		{

			// Subscribe the devices corresponding to the registration tokens to the
			// topic
			var response = await FirebaseMessaging.Instance.UnsubscribeFromTopic(TopicName);
		}
	}
}
