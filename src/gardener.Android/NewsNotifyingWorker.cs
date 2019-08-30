using System.Linq;
using Android.Content;
using AndroidX.Work;
using gardener.Models;
using gardener.Services;
using Realms;

namespace gardener.Droid
{
	public class NewsNotifyingWorker : Worker
	{
		#region .ctor
		public NewsNotifyingWorker(Context context, WorkerParameters workerParameters)
			: base(context, workerParameters)
		{
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

			if (news.Count > oldNews.Count && oldNews.Count > 0)
			{
				for (int i = 0; i < news.Count; i++)
				{
					if (oldNews[i] == null)
					{
						SendPushNotification(news[i]);
						break;
					}

					if (!news[i]
						.Uuid.Equals(oldNews[i]
										 .Uuid)
						|| oldNews[i] == null)
					{
						SendPushNotification(news[i]);
					}
				}
			}

			using (var transaction = realm.BeginWrite())
			{
				realm.RemoveAll<News>();
				foreach (News itemNews in news)
				{
					realm.Add(itemNews);
				}
				transaction.Commit();
			}
		}

		private void SendPushNotification(News news)
		{
			App.SendPushNotification("Новости рынка", news.Title);
		}
		#endregion
	}
}
