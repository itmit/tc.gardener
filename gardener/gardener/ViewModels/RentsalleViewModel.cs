using gardener.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using gardener.Views.Rent;

namespace gardener.ViewModels
{
    class RentsalleViewModel : INotifyPropertyChanged
    {
        public RentsalleViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _blocks = new ObservableCollection<Place>
            {
                new Place()
                {
                    ImagePath = "pict_3.png",
                    Title = "Вещевые ряды"
                },
                new Place()
                {
                    ImagePath = "pict_4.png",
                    Title = "ТЦ Садовод"
                },
                new Place()
                {
                    ImagePath = "pict_5.png",
                    Title = "Меха и кожа"
                }
            };
        }

        private INavigation _navigation;
        private ObservableCollection<Place> _blocks;
        private Place _selectedItem;

        public Place SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                _navigation.PushAsync(new ListSale(value));
            }
        }

        public ObservableCollection<Place> Blocks
        {
            get => _blocks;
            set
            {
                _blocks = value;
                OnPropertyChanged(nameof(Blocks));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
