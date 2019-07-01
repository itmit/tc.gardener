using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoursePage : ContentPage
	{
		#region .ctor
		public CoursePage()
		{
			InitializeComponent();
			var webView = new WebView();
			var htmlSource = new HtmlWebViewSource();
			htmlSource.Html = @"
<iframe style='width: 100%; border: 0; overflow: hidden; background-color:transparent; height: 263px; margin: 0, auto;' scrolling='no' src='https://fortrader.org/informers/getInformer?st=11&cat=7&title=%D0%9A%D1%83%D1%80%D1%81%D1%8B%20%D0%B2%D0%B0%D0%BB%D1%8E%D1%82%20%D0%A6%D0%91%20%D0%A0%D0%A4&texts=%7B%22toolTitle%22%3A%22%D0%92%D0%B0%D0%BB%D1%8E%D1%82%D0%B0%22%2C%22todayCourse%22%3A%22RUB%22%7D&mult=0.89&showGetBtn=0&hideHeader=0&hideDate=0&w=0&codes=1&colors=false&items=2%2C21&columns=todayCourse&toCur=11111'></iframe>
            ";
			webView.Source = htmlSource;
			Content = webView;
		}
		#endregion
	}
}
