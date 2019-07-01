using gardener.Models;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class NewsDetailViewModel : BaseViewModel
	{
		private HtmlWebViewSource _htmlSource;
		private string _image;

		public NewsDetailViewModel(News news)
		{
			Title = news.Title;
			Image = news.ImageUrl;

			HtmlSource = new HtmlWebViewSource
			{
				Html = news.Text
			};
		}

		public HtmlWebViewSource HtmlSource
		{
			get => _htmlSource;
			set => SetProperty(ref _htmlSource, value);
		}

		public string Image
		{
			get => _image;
			set => SetProperty(ref _image, value);
		}
	}
}
