using System.Collections.ObjectModel;
using System.ComponentModel;
using gardener.Models;
using gardener.Services;
using gardener.Views;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class NewsViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly INavigation _navigation;
		private ObservableCollection<News> _news;
		private readonly NewsDataStore _newsDataStore;
		private News _selectedItem;
		#endregion
		#endregion

		#region .ctor
		public NewsViewModel(INavigation navigation, NewsDataStore newsService)
		{
			_newsDataStore = newsService;
			_news = new ObservableCollection<News>();
			_navigation = navigation;

			Title = Properties.Strings.Marketnews;
		}
		#endregion

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
					_navigation.PushAsync(new NewsDetailPage(value));
					_selectedItem = null;
				}
				else
				{
					return;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion

		#region Public
		public async void UpdateNews()
		{
			News = await _newsDataStore.GetItemsAsync(true);
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			Title = Properties.Strings.Marketnews;
		}
	}
}
