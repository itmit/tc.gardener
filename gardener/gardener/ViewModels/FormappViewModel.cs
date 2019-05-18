using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using gardener.Annotations;
using gardener.Models;
using Newtonsoft.Json;

namespace gardener.ViewModels
{
	class FormappViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Place> _placeCollection;

		public FormappViewModel()
		{
		}

		public ObservableCollection<Place> PlaceCollection
		{
			get => _placeCollection;
			set
			{
				_placeCollection = value;
				OnPropertyChanged(nameof(PlaceCollection));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
