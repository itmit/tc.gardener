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
		private const string AllTopicName = "All";

		public async void SubscribeToAdminTopic()
		{
			// SubscribeToAdminTopic the devices corresponding to the registration tokens to the
			// topic
			var response = await FirebaseMessaging.Instance.SubscribeToTopic(TopicName);
		}

		public async void UnsubscribeToAdminTopic()
		{

			// SubscribeToAdminTopic the devices corresponding to the registration tokens to the
			// topic
			var response = await FirebaseMessaging.Instance.UnsubscribeFromTopic(TopicName);
		}

		public async void SubscribeToAllTopic()
		{
			await FirebaseMessaging.Instance.SubscribeToTopic(AllTopicName);
		}
	}
}
