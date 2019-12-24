using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsDetailPage : ContentPage
	{
		public NewsDetailPage(News news)
		{
			InitializeComponent();
			BindingContext = news;
			WebView webView = new WebView();
			webView.Navigating += WebViewOnNavigating;
			var htmlSource = new HtmlWebViewSource
			{
				Html = news.Text
			};
			webView.Source = htmlSource;
			webView.VerticalOptions = LayoutOptions.FillAndExpand;
			webView.HorizontalOptions = LayoutOptions.FillAndExpand;
			WebContent.Children.Add(webView);
		}
		public async void OpenBrowser(string uri)
		{
			if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
			{
				await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
			}
		}

		private void WebViewOnNavigating(object sender, WebNavigatingEventArgs e)
		{
			if (e.Url.StartsWith("http") || e.Url.StartsWith("https"))
			{
				OpenBrowser(e.Url);
				e.Cancel = true;
			}
		}
	}
}