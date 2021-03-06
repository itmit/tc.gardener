﻿using System.Collections.Generic;
using System.ComponentModel;
using gardener.Models;
using gardener.Views.ListView;
using Xamarin.Forms;

namespace gardener.ViewModels
{
	public class SelectFloorViewModel : BaseViewModel
	{
		#region Data
		#region Fields
		private readonly Block _block;
		private readonly INavigation _navigation;
		private Floor _selectedItem;
		#endregion
		#endregion

		#region .ctor
		public SelectFloorViewModel(Block block, INavigation navigation)
		{
			Title = Properties.Strings.SelectFloor;
			_block = block;
			_navigation = navigation;
			Floors = block.Floors;
		}
		#endregion

		#region Properties
		public List<Floor> Floors
		{
			get;
			set;
		}

		public Floor SelectedItem
		{
			get => _selectedItem;
			set
			{
				_selectedItem = value;
				if (value != null)
				{
					_navigation.PushAsync(new ListSalePage(_block, value.Value));
					_selectedItem = null;
				}

				OnPropertyChanged(nameof(SelectedItem));
			}
		}
		#endregion

		protected override void OnLanguageChanged()
		{
			Title = Properties.Strings.SelectFloor;
		}
	}
}
