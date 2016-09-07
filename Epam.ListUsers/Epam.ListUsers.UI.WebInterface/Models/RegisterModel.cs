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
        
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string RememberPassword { get; set; }

        public bool ToMemorize { get; set; }

        public static bool TryToRegister(RegisterModel model)
        {
            if (model.Password != model.RememberPassword)
            {
                return false;
            }
            var textLine = String.Format("{0}/{1}", model.UserName, model.Password);
            File.AppendAllLines(PathForAuthenticationUsers, new string[] { textLine });
            FormsAuthentication.RedirectFromLoginPage(model.UserName, createPersistentCookie: model.ToMemorize);
            return true;
        }
    }
}