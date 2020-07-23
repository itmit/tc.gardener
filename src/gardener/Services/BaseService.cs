using System.Net.Http;
using System.Net.Http.Headers;

namespace gardener.Services
{
	public abstract class BaseService
	{
		private const string DevDomain = "http://tc.itmit-studio.ru";
		private const string ProdDomain = "https://sadovod-online.com";

		protected static string Domain
		{
			get
			{
#if DEBUG
				return DevDomain;
#else
				return ProdDomain;
#endif
			}
		}

		protected BaseService()
		{
			HttpClient = new HttpClient();
			HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		protected static HttpClient HttpClient
		{
			get;
			private set;
		}
	}
}
