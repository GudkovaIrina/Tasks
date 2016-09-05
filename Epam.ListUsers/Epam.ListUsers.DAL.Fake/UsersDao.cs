using Epam.ListUsers.DAL.Abstract;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.DAL.Fake
{
    public class UsersDao : IUsersDao
    {
        private Dictionary<Guid, User> _users = new Dictionary<Guid, User>();

        public UsersDao()
        {
            _users = new Dictionary<Guid, User>();
        }

        public bool Add(User user)
        {
            bool result = !_users.ContainsKey(user.Id);
            if (result)
            {
                _users.Add(user.Id, user);
            }

            return result;
        }

        public User GetById(Guid id)
        {
            User user;
            bool result = _users.TryGetValue(id, out user);
            if (result)
            {
                return user;
            }
            throw new ArgumentException("User with such id is not exist");
        }

        public List<User> GetAll()
        {
            return this._users.Values.ToList();
        }

        public bool Edit(User newUser)
        {
            bool result = _users.ContainsKey(newUser.Id);
            if (result)
            {
                _users[newUser.Id].Name = newUser.Name;
                _users[newUser.Id].DateOfBirth = newUser.DateOfBirth;
            }

            return result;
        }

        public bool Remove(User user)
        {
            bool result = _users.ContainsKey(user.Id);
            if (result)
            {
                _users.Remove(user.Id);
            }

            return result;
        }

        public bool ToAward(User user, Award award)
        {
            throw new NotImplementedException();
        }

        public bool ReAward(User user, Award award)
        {
            throw new NotImplementedException();
        }


        public void SetImage(Guid id, HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }

        public byte[] GetImage(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}