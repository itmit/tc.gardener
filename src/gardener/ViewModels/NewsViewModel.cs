using System.Collections.ObjectModel;
using gardener.Models;
using gardener.Services;
using gardener.Views;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class NewsViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly INavigation _navigation;
		private News _selectedItem;
		private ObservableCollection<News> _news;
		private readonly NewsDataStore _newsDataStore;
		#endregion
		#endregion

		#region .ctor
		public NewsViewModel(INavigation navigation, NewsDataStore newsService)
		{
			Title = "Новости рынка";
			_newsDataStore = newsService;
			_news = new ObservableCollection<News>();
			_navigation = navigation;
		}
		#endregion

		public async void UpdateNews()
		{
			News = await _newsDataStore.GetItemsAsync(true);
		}

		#region Properties
		public ObservableCollection<News> News
		{
			get => _news;
			set => SetProperty(ref _news, value);
		}

		public News SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				if (value != null)
				{
					_selectedItem = null;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion
	}
}
