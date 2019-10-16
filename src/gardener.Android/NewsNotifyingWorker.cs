using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Util;
using AndroidX.Work;
using gardener.Models;
using gardener.Services;
using Realms;

namespace gardener.Droid
{
	public class NewsNotifyingWorker : Worker
	{
		private readonly string _tag = typeof(NewsNotifyingWorker).FullName;

		#region .ctor
		public NewsNotifyingWorker(Context context, WorkerParameters workerParameters)
			: base(context, workerParameters)
		{
			Log.Info(_tag, $"Worker is starter;");
		}
		#endregion

		#region Overrided
		public override Result DoWork()
		{
			CheckNews();

			return Result.InvokeSuccess();
		}

		private async void CheckNews()
		{
			var service = new NewsService();
			var news = (await service.GetHourlyNews()).OrderBy(x => x.CreatedAt).ToList();
			var realm = Realm.GetInstance();
			var oldNews = realm.All<News>().OrderBy(x => x.CreatedAt).ToList();

			List<News> newsForSave = new List<News>();
			
			Log.Info(_tag, $"Count hourly news: {news.Count}, count saved news: {oldNews.Count}");

			for (int i = 0; i < news.Count; i++)
			{
				if (oldNews[i] == null)
				{
					newsForSave.Add(news[i]);
					SendPushNotification(news[i]);
					break;
				}

				if (!news[i]
					.Uuid.Equals(oldNews[i]
										.Uuid))
				{
					newsForSave.Add(news[i]);
					SendPushNotification(news[i]);
				}
			}
			

			using (var transaction = realm.BeginWrite())
			{
				realm.RemoveAll<News>();
				foreach (News itemNews in newsForSave)
				{
					realm.Add(itemNews);
				}
				transaction.Commit();
			}
		}

		private void SendPushNotification(News news)
		{
			//var service = new PushNotificationService();
			//service.PushNotification("Новости рынка", news.Title);
			App.SendPushNotification("Новости рынка", news.Title);
		}
		#endregion
	}
}
