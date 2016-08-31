using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.ListUsers.UI.ConsoleInterface
{
    public class CommandsForMenu
    {
        private List<User> users;
        private List<Award> awards;
        private User currentUser;
        private Award currentAward;
        private UsersLogic _logic;

        public CommandsForMenu()
        {
            _logic = new UsersLogic();
            users = new List<User>();
            awards = new List<Award>();
        }

        public void AddUser()
        {
            User user = CreateNewUser();
            _logic.AddUser(user);
        }

        public void GetUsers()
        {
            users = _logic.GetAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, users[i].Name);
            }
        }

        public void DetailsOfCurrentUser()
        {
            User user = users[GetNumberEntities("Введите номер пользователя: ", users.Count)];
            currentUser = _logic.GetUserById(user.Id);
            Console.WriteLine("{0}\t{1}\t{2}", currentUser.Name, currentUser.DateOfBirth.Date, currentUser.Age());
            Console.WriteLine("Награды:");
            for (int i = 0; i < currentUser.Awards.Count; i++)
            {
                Console.WriteLine("{0}. {1}",i + 1, currentUser.Awards[i].Title);
            }
        }

        public void EditCurrentUser()
        {
            User newUser = CreateNewUser();
            newUser.Id = currentUser.Id;
            _logic.EditUser(newUser);
        }

        public void RemoveCurrentUser()
        {
            _logic.RemoveUser(currentUser);
        }

        public void ToAwardCurrentUser()
        {
            GetAwards();
            _logic.ToAward(currentUser,
                awards[GetNumberEntities("Введите номер награды, которой хотите наградить текущего пользователя: ",
                                         awards.Count)]);
        }

        public void ReAwardCurrentUser()
        {
            
            for (int i = 0; i < currentUser.Awards.Count; i++)
            {
                Console.WriteLine("{0}. {1}",i + 1, currentUser.Awards[i]);
            }
            Award award = currentUser.Awards[GetNumberEntities(
                                                "Введите номер награды у пользователя, которую хотите забрать: ",
                                                awards.Count)];
            _logic.ReAward(currentUser, award);
        }

        public void AddAward()
        {
            Award award = CreateNewAward();
            _logic.AddAward(award);
        }

        public void GetAwards()
        {
            awards = _logic.GetAllAwards();
            for (int i = 0; i < awards.Count; i++)
            {
                Console.WriteLine("{0}. {1}",i+1, awards[i].Title);
            }
        }

        public void DetailsOfCurrentAward()
        {
            Award award = awards[GetNumberEntities("Введите номер награды: ", awards.Count)];
            currentAward = _logic.GetAwardById(award.Id);
            Console.WriteLine(currentAward.Title);
            Console.WriteLine("Пользователи обладающие этой наградой: ");
            foreach (var user in _logic.GetAllUsersWithAward(currentAward))
            {
                Console.WriteLine(user.Name);
            }
        }

        public void EditCurrentAward()
        {
            Award newAward = CreateNewAward();
            newAward.Id = currentAward.Id;
            _logic.EditAward(newAward);
        }

        public void RemoveCurrentAward()
        {
            _logic.RemoveAward(currentAward);
        }

        private string ReaderData(string request, Predicate<string> condition)
        {
            Console.WriteLine(request);
            string data = Console.ReadLine();
            while (! condition(data))
            {
                Console.WriteLine("Введены некорректные данные!");
                Console.WriteLine(request);
                data = Console.ReadLine();
            }
            return data;
        }
        
        private User CreateNewUser()
        {
            string name = ReaderData(
                          "Введите ФИО пользователя:",
                          data => Regex.IsMatch(data, Constants.PatternForNameOfUser));
            DateTime dateOfBirth = DateTime.Parse(
                                            ReaderData(
                                            "Введите дату рождения пользователя в формате dd.mm.yyyy:",
                                            data => Regex.IsMatch(
                                                          data,
                                                          Constants.PatternForDateOfBirthOfUser)
                                                    && DateTime.Parse(data)<DateTime.Now));
            return new User(name, dateOfBirth);
        }
        
        private Award CreateNewAward()
        {
            string title = ReaderData(
                           "Введите название награды:",
                           data => Regex.IsMatch(data, Constants.PatternForTitleOfAward));
            return new Award(title);
        }

        private int GetNumberEntities(string request, int countOfCollection)
        {
            return int.Parse(
                       ReaderData(
                       request,
                       data => Regex.IsMatch(
                                     data,
                                     Constants.PatternForNameNumberOfEntity)
                               && int.Parse(data) <= countOfCollection)) - 1;
        }
    }
}
