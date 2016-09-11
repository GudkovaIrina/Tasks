using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Web;

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

        void SetImage(Guid id, HttpPostedFileBase file);

        byte[] GetImage(Guid id);

        bool EditImage(Guid id, HttpPostedFileBase file);
    }
}