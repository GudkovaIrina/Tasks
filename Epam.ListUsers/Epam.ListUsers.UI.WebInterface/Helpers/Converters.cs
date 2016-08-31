using Epam.ListUsers.Entities;
using Epam.ListUsers.UI.WebInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.UI.WebInterface.Helpers
{
    public class Converters
    {
        public static UserModelForDetails ToUserModelForDetails(User user)
        {
            var userModel = new UserModelForDetails();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.DateOfBirth = user.DateOfBirth.ToShortDateString();
            userModel.Age = user.Age();
            userModel.Awards = user.Awards.Select(a => a.Title).ToList();
            return userModel;
        }

        public static User ToUserForLogic(UserModelForCreate userModel)
        {
            DateTime dateOfBirth;
            if (DateTime.TryParse(userModel.DateOfBirth, out dateOfBirth))
            {
                var user = new User(userModel.Name, dateOfBirth){Id = userModel.Id};
                return user;
            }
            else
            {
                throw new ArgumentException("Data are not valid!");
            }
        }

        public static UserModelForEdit ToUserModelForEdit(User user)
        {
            var userModel = new UserModelForEdit();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.DateOfBirth = user.DateOfBirth.ToShortDateString();
            userModel.Awards = user.Awards;
            return userModel;
        }

        public static User ToUserForLogic(UserModelForEdit userModel)
        {
            DateTime dateOfBirth;
            if (DateTime.TryParse(userModel.DateOfBirth, out dateOfBirth))
            {
                var user = new User(userModel.Name, dateOfBirth) { Id = userModel.Id, Awards = userModel.Awards };
                return user;
            }
            else
            {
                throw new ArgumentException("Data are not valid!");
            }
        }

        public static AwardModelForDetailsAndReAward ToAwardModelForDetails(Award award, User user)
        {
            var awardModel = new AwardModelForDetailsAndReAward();
            awardModel.IdAward = award.Id;
            awardModel.Title = award.Title;
            awardModel.IdUser = user.Id;
            awardModel.NameUser = user.Name;
            return awardModel;
        }

        public static AwardModel ToAwardModel(Award award)
        {
            var awardModel = new AwardModel();
            awardModel.Id = award.Id;
            awardModel.Title = award.Title;
            return awardModel;
        }

        public static AwardModelForDetails ToAwardModelForDetails(Award award)
        {
            var awardModel = new AwardModelForDetails();
            awardModel.Id = award.Id;
            awardModel.Title = award.Title;
            return awardModel;
        }

        public static Award ToAwardForLogic(AwardModel awardModel)
        {
            var award = new Award(awardModel.Title) { Id = awardModel.Id};
            return award;
        }
    }
}