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
            WebView webView = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"
<iframe style='width: 100%; border: 0; overflow: hidden; background - color:transparent; height: 2177px' scrolling='no' src='https://fortrader.org/informers/getInformer?st=11&cat=7&title=%D0%9A%D1%83%D1%80%D1%81%D1%8B%20%D0%B2%D0%B0%D0%BB%D1%8E%D1%82%20%D0%A6%D0%91%20%D0%A0%D0%A4&texts=%7B%22toolTitle%22%3A%22%D0%92%D0%B0%D0%BB%D1%8E%D1%82%D0%B0%22%2C%22todayCourse%22%3A%22RUB%22%7D&mult=1&showGetBtn=0&hideHeader=0&hideDate=0&w=0&codes=1&colors=false&items=2%2C21%2C30%2C11%2C47%2C27%2C6%2C40%2C49%2C14%2C55%2C53%2C60%2C28%2C48%2C29%2C13%2C54%2C59%2C10%2C18%2C39%2C22%2C8%2C16%2C20%2C45%2C43%2C17%2C5%2C3%2C44%2C1&columns=todayCourse&toCur=11111'></iframe>
            ";
			webView.Source = htmlSource;
			Content = webView;
		}
		#endregion
	}
}
