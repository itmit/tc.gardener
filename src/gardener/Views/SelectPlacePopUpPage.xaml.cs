﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectPlacePopUpPage : PopupPage
	{
		public SelectPlacePopUpPage(BaseViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}