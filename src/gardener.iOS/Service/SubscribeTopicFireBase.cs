﻿using Firebase.CloudMessaging;
using gardener.iOS.Service;
using gardener.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SubscribeTopicFireBase))]
namespace gardener.iOS.Service
{
	public class SubscribeTopicFireBase : ISubscribeTopicFireBase
	{
		private const string TopicName = "AdminNotification";
		private const string AllTopicName = "All";

		public void SubscribeToAdminTopic()
		{
			Messaging.SharedInstance.Subscribe(TopicName);
		}

		public void UnsubscribeToAdminTopic()
		{
			Messaging.SharedInstance.Unsubscribe(TopicName);
		}

		public void SubscribeToAllTopic()
		{
			Messaging.SharedInstance.Subscribe(AllTopicName);
		}
	}
}
