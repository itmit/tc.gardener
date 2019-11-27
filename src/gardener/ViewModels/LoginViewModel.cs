using gardener.Models;
using gardener.Services;
using gardener.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Realms;
using Xamarin.Forms;

namespace gardener.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
        private AuthService _authService = new AuthService();
		private MasterViewModel _mvm;

		public LoginViewModel(MasterViewModel mvm)
		{
			_mvm = mvm;
			Input = new Command(obj =>
                                        {
                                            LoginCommandExecute(Login, Password);
										},
                                        obj => Login != string.Empty && Password != string.Empty);
        }

		public Realm Realm => Realm.GetInstance();

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand Input
        {
            get;
        }

		//public abstract void OnLanguageChange();

		public delegate void SignInEventHandler();

		//Событие OnCount c типом делегата SignInEventHandler.

		public static event SignInEventHandler SignIn;

		private async void LoginCommandExecute(string login, string password)
        {
            bool result = await _authService.LoginAsync(login, password);

            if (result)
			{
				var service = DependencyService.Get<ISubscribeTopicFireBase>();
				service.Subscribe();

				_mvm.Name = login;
				if (string.IsNullOrEmpty(login))
				{
					return;
				}

				using (var transaction = Realm.BeginWrite())
				{
					Realm.Add(new User
					{
						Login = login
					});
					transaction.Commit();
				}

				_mvm.Visible = true;

				await Application.Current.MainPage.DisplayAlert("Уведомление", "Вход выполнен!", "ОК");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", "Неверный логин или пароль!", "ОК");
            }
		}

        protected override void OnLanguageChanged()
        {
        }

		private static void OnSignIn()
		{
			SignIn?.Invoke();
		}
	}
}