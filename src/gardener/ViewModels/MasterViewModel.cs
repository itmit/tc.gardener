using gardener.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Realms;

namespace gardener.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        private string _name;
        private bool _visible;

		public MasterViewModel()
		{
			var user = Realm.All<User>()
				 .SingleOrDefault();

			if (user != null)
			{
				Name = user.Login;
				Visible = true;
			}
		}

		public Realm Realm => Realm.GetInstance();

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
