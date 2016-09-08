using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.ListUsers.UI.WebInterface.Models
{
    public class MyRoleProvider : RoleProvider
    {
        public override string[] GetAllRoles()
        {
            string PathForRolesAtAuthentication = ConfigurationManager.AppSettings["PathForRolesAtAuthentication"];
            string[] _roles = File.ReadAllLines(PathForRolesAtAuthentication);
            return _roles;
        }

        public override string[] GetRolesForUser(string userName)
        {
            string PathForGetRolesForUser = ConfigurationManager.AppSettings["PathForGetRolesForUser"];
            string[] _usersWithRoles = File.ReadAllLines(PathForGetRolesForUser);
            foreach (var user in _usersWithRoles)
            {
                int position = user.IndexOf("/");
                string name = user.Substring(0, position);
                if (name == userName)
                {
                    string roles = user.Substring(position + 1);
                    string[] rolesOfuser = roles.Split(new char[] { ',' });
                    return rolesOfuser;
                }
            }
            return new string[0];
        }

        #region
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}