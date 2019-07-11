﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using gardener.Models;
using gardener.Services;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		#region Data
		#region Fields
		private bool _isBusy;

		private string _title = string.Empty;
		#endregion
		#endregion

		#region .ctor
		public BaseViewModel()
		{
			if (Market == null)
			{
				Market = new Market();
			}

			PropertyChanged += OnPropertyChanged;
		}
		#endregion

		#region Properties
		public static Market Market
		{
			get;
			private set;
		}

		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}
		#endregion

		#region Protected
		protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
			{
				return false;
			}

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}
		#endregion

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;

			changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		//public abstract void OnLanguageChange();

		public delegate void MethodContainer();

		//Событие OnCount c типом делегата MethodContainer.

		public static event MethodContainer LanguageChange;

		protected abstract void OnPropertyChanged(object sender, PropertyChangedEventArgs e);
	}
}
