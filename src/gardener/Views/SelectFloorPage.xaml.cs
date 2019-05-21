﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gardener.Models;
using gardener.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectFloorPage : ContentPage
	{
		public SelectFloorPage(Block block)
		{
			InitializeComponent();

			BindingContext = new SelectFloorViewModel(block, Navigation);
		}
	}
}