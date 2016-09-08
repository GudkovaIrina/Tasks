using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class RolesOfUserModel
    {
        private static string PathForAuthenticationUsers = ConfigurationManager.AppSettings["PathForAuthenticationUsers"];
        private static string PathForGetRolesForUser = ConfigurationManager.AppSettings["PathForGetRolesForUser"];
        private static MyRoleProvider provider = new MyRoleProvider();

        public string UserName { get; set; }

        public List<string> Roles { get; set; }

        public static IEnumerable<RolesOfUserModel> GetAll()
        {
            string[] _lines = File.ReadAllLines(PathForAuthenticationUsers);
            foreach (var line in _lines)
            {
                var user = new RolesOfUserModel();
                int position = line.IndexOf("/");
                user.UserName = line.Substring(0, position);
                user.Roles = provider.GetRolesForUser(user.UserName).ToList();
                yield return user;
            }
        }

        public static string AddRoleToUser(string userWithRoles, string roleForAdd)
        {
            int position = userWithRoles.IndexOf("/");
            string roles = userWithRoles.Substring(position + 1);
            if (!roles.Contains(roleForAdd))
            {
                return userWithRoles + "," + roleForAdd;
            }
            return userWithRoles;
        }

        //public static void RemoveRoleAtUser(string userName, string roleForRemove)
        //{
        //    string[] _usersWithRoles = File.ReadAllLines(PathForGetRolesForUser);
        //    for (int i = 0; i < _usersWithRoles.Length; i++)
        //    {
        //        int position = _usersWithRoles[i].IndexOf("/");
        //        string name = _usersWithRoles[i].Substring(0, position);
        //        if (name == userName)
        //        {
        //            string roles = _usersWithRoles[i].Substring(position + 1);
        //            position = roles.IndexOf(roleForRemove);
        //            int startIndex = position == 0 ? 0 : position - 1;
        //            roles = roles.Remove(startIndex, roleForRemove.Length + 1);
        //            _usersWithRoles[i] = name + "/" + roles;
        //        }
        //    }
        //    File.WriteAllLines(PathForGetRolesForUser, _usersWithRoles);
        //}

        public static string RemoveRoleAtUser(string userWithRoles, string roleForRemove)
        {
            int position = userWithRoles.IndexOf("/");
            string name = userWithRoles.Substring(0, position);
            string roles = userWithRoles.Substring(position + 1);
            position = roles.IndexOf(roleForRemove);
            int startIndex = position == 0 ? 0 : position - 1;
            roles = roles.Remove(startIndex, roleForRemove.Length + 1);
            return name + "/" + roles;
            
        }

        public static void EditRolesOfUser(string userName, string role, Func<string, string, string> func) 
        {
            string[] _usersWithRoles = File.ReadAllLines(PathForGetRolesForUser);
            for (int i = 0; i < _usersWithRoles.Length; i++)
            {
                int position = _usersWithRoles[i].IndexOf("/");
                string name = _usersWithRoles[i].Substring(0, position);
                if (name == userName)
                {
                    _usersWithRoles[i] = func(_usersWithRoles[i], role);
                }
            }
            File.WriteAllLines(PathForGetRolesForUser, _usersWithRoles);
        }
    }
}