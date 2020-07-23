using gardener.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gardener.Services
{
	/// <summary>
	/// Представляет сервис для авторизации.
	/// </summary>
    public class AuthService : BaseService
    {
        /// <summary>
        /// Задает адрес для авторизации
        /// </summary>
        private const string Address = "{0}/api/admin/login";

        /// <summary>
        /// Отправляет введенные данные пользователем на сервер
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        public async Task<bool> LoginAsync(string login, string password)
        {
            var encodedContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {
                    "login", login
                },
                {
                    "password", password
                }
            });
            var response = await HttpClient.PostAsync(string.Format(Address, Domain), encodedContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(jsonString);

			return response.IsSuccessStatusCode;
        }
    }
}
