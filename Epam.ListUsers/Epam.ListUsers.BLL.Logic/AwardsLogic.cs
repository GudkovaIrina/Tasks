using Epam.ListUsers.DAL.XMLFiles;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Web;

namespace Epam.ListUsers.BLL.Logic
{
    public partial class UsersLogic
    {
        

        public bool AddAward(Award award)
        {
            return this._awards.Add(award);
        }

        public Award GetAwardById(Guid id)
        {
            return _awards.GetById(id);
        }

        public List<Award> GetAllAwards()
        {
            return _awards.GetAll();
        }

        public bool EditAward(Award newAward)
        {
            return _awards.Edit(newAward);
        }

        public bool RemoveAward(Award award)
        {
            return _awards.Remove(award);
        }

        public List<User> GetAllUsersWithAward(Award award)
        {
            return _awards.GetAllUsersWithAward(award);
        }

        public void SetImageOfAward(Guid id, HttpPostedFileBase file)
        {
            _awards.SetImage(id, file);
        }

        public byte[] GetImageOfAward(Guid id)
        {
            return _awards.GetImage(id);
        }
    }
}