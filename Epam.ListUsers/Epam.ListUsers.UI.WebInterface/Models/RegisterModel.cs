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
    public class RegisterModel
    {
        private static string PathForAuthenticationUsers = ConfigurationManager.AppSettings["PathForAuthenticationUsers"];
        private static string PathForGetRolesForUser = ConfigurationManager.AppSettings["PathForGetRolesForUser"];
        
        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [RegularExpression(@"[\w]{3,15}",ErrorMessage="Имя пользователя может содержать от 3 до 15 букв, цифр или знак подчеркивания")]  
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[\w]{3,15}", ErrorMessage = "Пароль может содержать от 3 до 15 букв, цифр или знак подчеркивания")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для ввода")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[\w]{3,15}", ErrorMessage = "Пароль может содержать от 3 до 15 букв, цифр или знак подчеркивания")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string RememberPassword { get; set; }

        public bool ToMemorize { get; set; }

        public static bool TryToRegister(RegisterModel model)
        {
            
            if (model.Password != model.RememberPassword)
            {
                return false;
            }
            string[] _lines = File.ReadAllLines(PathForAuthenticationUsers);
            foreach (var line in _lines)
            {
                int position = line.IndexOf("/");
                string userName = line.Substring(0, position);
                if (userName == model.UserName)
                {
                    return false;
                }
            }
            var textLine = String.Format("{0}/{1}", model.UserName, model.Password);
            File.AppendAllLines(PathForAuthenticationUsers, new string[] { textLine });
            textLine = String.Format("{0}/user",model.UserName);
            File.AppendAllLines(PathForGetRolesForUser, new string[] { textLine });
            FormsAuthentication.RedirectFromLoginPage(model.UserName, createPersistentCookie: model.ToMemorize);
            return true;
        }
    }
}