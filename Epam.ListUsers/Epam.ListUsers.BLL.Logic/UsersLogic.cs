using Epam.ListUsers.DAL.Abstract;
using Epam.ListUsers.DAL.XMLFiles;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Web;

namespace Epam.ListUsers.BLL.Logic
{
    public partial class UsersLogic
    {
        private int AdultAge = 18;
        private IUsersDao _users;
        private AwardsDao _awards;

        public UsersLogic()
        {
            this._users = new UsersDao();
            this._awards = new AwardsDao();
        }

        public bool AddUser(User user)
        {
            return this._users.Add(user);
        }

        public User GetUserById(Guid id)
        {
            return _users.GetById(id);
        }

        public List<User> GetAllUsers()
        {
            return _users.GetAll();
        }

        public bool EditUser(User newUser)
        {
            return _users.Edit(newUser);
        }

        public bool RemoveUser(User user)
        {
            return _users.Remove(user);
        }

        public List<User> GetAllAdultUser()
        {
            return _users.GetAll().FindAll(u => u.Age() >= AdultAge);
        }

        public bool ToAward(User user, Award award)
        {
            return _users.ToAward(user, award);
        }

        public bool ReAward(User user, Award award)
        {
            return _users.ReAward(user, award);
        }

        public void SetImageOfUser(Guid id, HttpPostedFileBase file)
        {
            _users.SetImage(id, file);
        }

        public byte[] GetImageOfUser(Guid id)
        {
            return _users.GetImage(id);
        }
    }
}