using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class LoginModel
    {
        private static string PathForAuthenticationUsers = ConfigurationManager.AppSettings["PathForAuthenticationUsers"];

        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [RegularExpression(@"[\w]{3,15}", ErrorMessage = "Имя пользователя может содержать от 3 до 15 букв, цифр или знак подчеркивания")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [RegularExpression(@"[\w]{3,15}", ErrorMessage = "Пароль может содержать от 3 до 15 букв, цифр или знак подчеркивания")]
        public string Password { get; set; }

        public bool ToMemorize { get; set; }

        public LoginModel()
        {
        }

        public LoginModel(string user)
        {
            int position = user.IndexOf("/");
            this.UserName = user.Substring(0, position);
            this.Password = user.Substring(position + 1, user.Length - position - 1);
        }

        public static bool TryToLogin(LoginModel model)
        {
            string[] _lines = File.ReadAllLines(PathForAuthenticationUsers);
            foreach (var line in _lines)
            {
                var user = new LoginModel(line);
                if (user.UserName == model.UserName && user.Password == model.Password)
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, createPersistentCookie: model.ToMemorize);
                    return true;
                }
            }
            return false;
        }

        internal static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}