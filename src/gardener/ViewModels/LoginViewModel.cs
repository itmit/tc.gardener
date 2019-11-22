using gardener.Models;
using gardener.Services;
using gardener.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace gardener.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _login;
        private string _password;
        private AuthService _authService = new AuthService();

        public LoginViewModel(MasterViewModel mvm)
        {
            Input = new Command(obj =>
                                        {
                                            LoginCommandExecute(Login, Password);
                                            mvm.Name = Login;
                                            if (!string.IsNullOrEmpty(mvm.Name))
                                            {
                                                mvm.Visible = true;
                                            }
                                        },
                                        obj => Login != string.Empty && Password != string.Empty);
        }

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

        private async void LoginCommandExecute(string login, string password)
        {
            bool result = await _authService.LoginAsync(login, password);

            if (result)
			{
				var service = DependencyService.Get<ISubscribeTopicFireBase>();
				service.Subscribe();
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
    }
}