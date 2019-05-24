using System.Net.Http;
using gardener.Views.ListView;

namespace gardener.ViewModels
{
	/// <summary>
	/// Представляет ViewModel для <see cref="FormAppBuyPage"/>
	/// </summary>
	public class FormAppBuyViewModel :BaseViewModel
	{
		public FormAppBuyViewModel()
		{
			Title = "Форма заявки покупки";
			SendFormCommand = new RelayCommand(x =>
			{
				SendForm();
			}, x => true);
		}

		public RelayCommand SendFormCommand
		{
			get;
		}

		private void SendForm()
		{
			//var client = new PostClient();
			//client

		}
	}
}
