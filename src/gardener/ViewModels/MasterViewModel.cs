using gardener.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gardener.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        private string _name;
        private bool _visible;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool Visible 
        { 
            get => _visible; 
            set => SetProperty(ref _visible, value); 
        }

        protected override void OnLanguageChanged() { }
    }
}
