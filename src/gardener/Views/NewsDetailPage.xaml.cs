using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.Models;
using gardener.ViewModels;
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

			//BindingContext = new NewsDetailViewModel(news);
			Label.Text = news.Title;
			Image.Source = news.ImageUrl;
			WebView webView = new WebView();
			var htmlSource = new HtmlWebViewSource
			{
				Html = news.Text
			};
			webView.Source = htmlSource;
			webView.VerticalOptions = LayoutOptions.FillAndExpand; 
			WebContent.Children.Add(webView);
		}
	}
}