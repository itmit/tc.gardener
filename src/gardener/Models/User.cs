using Realms;

namespace gardener.Models
{
    public class User : RealmObject
    {
        /// <summary>
        /// Возвращает логин пользователя.
        /// </summary>
        public string Login
        {
            get;
            set;
        }
    }
}
