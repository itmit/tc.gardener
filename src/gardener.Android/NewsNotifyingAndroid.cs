using System;
using AndroidX.Work;
using gardener.Services;
using Java.Util;

namespace gardener.Droid
{
	public class NewsNotifyingAndroid : INewsNotifying
	{
		private UUID _workId;

		public void RunService()
		{
			PeriodicWorkRequest taxWorkRequest = PeriodicWorkRequest
												 .Builder
												 .From<NewsNotifyingWorker>(TimeSpan.FromMinutes(10)
												 ).Build();
			WorkManager.Instance.Enqueue(taxWorkRequest);
			_workId = taxWorkRequest.Id;
		}

		public void StopService()
		{
			WorkManager.Instance.CancelWorkById(_workId);
		}
	}
}
