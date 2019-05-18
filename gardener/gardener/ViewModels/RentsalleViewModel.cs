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
            _blocks = new ObservableCollection<Block>
            {
                new Block()
                {
                    ImagePath = "pict_3.png",
                    Title = "Вещевые ряды"
                },
                new Block()
                {
                    ImagePath = "pict_4.png",
                    Title = "ТЦ Садовод"
                },
                new Block()
                {
                    ImagePath = "pict_5.png",
                    Title = "Меха и кожа"
                }
            };
        }

        private INavigation _navigation;
        private ObservableCollection<Block> _blocks;
        private Block _selectedItem;

        public Block SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (value != null)
                {
                    _navigation.PushAsync(new ListSale(value));
                    _selectedItem = null;
                }

                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Block> Blocks
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
