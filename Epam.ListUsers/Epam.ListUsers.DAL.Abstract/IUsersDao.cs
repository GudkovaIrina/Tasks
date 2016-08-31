using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;

namespace Epam.ListUsers.DAL.Abstract
{
    public interface IUsersDao
    {
        bool Add(User user);

        User GetById(Guid id);

        List<User> GetAll();

        bool Edit(User newUser);

        bool Remove(User user);

        bool ToAward(User user, Award award);

        bool ReAward(User user, Award award);
    }
}