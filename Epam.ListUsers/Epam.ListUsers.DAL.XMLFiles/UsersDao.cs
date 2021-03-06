﻿using Epam.ListUsers.DAL.Abstract;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Epam.ListUsers.DAL.XMLFiles
{
    public class UsersDao : IUsersDao
    {
        private DataCache _dataCache;
        private string PuthToImagesForUsers = ConfigurationManager.AppSettings["PathForImageOfUsers"];
        private string PuthToDefaultImageForUsers = ConfigurationManager.AppSettings["PathForDefaultImageOfUsers"];

        public UsersDao()
        {
            _dataCache = DataCache.Instance;
        }

        public bool Add(User user)
        {
            var users = _dataCache.GetUsers();
            bool result = !users.ContainsKey(user.Id);
            if (result)
            {
                users.Add(user.Id, user);
                _dataCache.PutUsers(users);
            }

            return result;
        }

        public User GetById(Guid id)
        {
            User user;
            var users = _dataCache.GetUsers();
            bool result = users.TryGetValue(id, out user);
            if (result)
            {
                GetAwardsOfUser(user);
                return user;
            }
            throw new ArgumentException("User with such Id is not exist");
        }

        public List<User> GetAll()
        {
            return _dataCache.GetUsers().Values.ToList();
        }

        public bool Edit(User newUser)
        {
            var users = _dataCache.GetUsers();
            bool result = users.ContainsKey(newUser.Id);
            if (result)
            {
                users[newUser.Id].Name = newUser.Name;
                users[newUser.Id].DateOfBirth = newUser.DateOfBirth;
                _dataCache.PutUsers(users);
            }

            return result;
        }

        public bool Remove(User user)
        {
            var users = _dataCache.GetUsers();
            bool result = users.ContainsKey(user.Id);
            if (result)
            {
                users.Remove(user.Id);
                var relations = _dataCache.GetRelations();
                if (relations.ContainsKey(user.Id))
                {
                    relations.Remove(user.Id);
                    _dataCache.PutRelations(relations);
                }
                _dataCache.PutUsers(users);
                string fileName = PuthToImagesForUsers + user.Id.ToString();
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }

            return result;
        }

        public bool ToAward(User user, Award award)
        {
            var users = _dataCache.GetUsers();
            var awards = _dataCache.GetAwards();
            var relations = _dataCache.GetRelations();
            var result = users.ContainsKey(user.Id) && awards.ContainsKey(award.Id);
            if (result)
            {
                if (relations.ContainsKey(user.Id))
                {
                    if (!relations[user.Id].IdOfAwards.Contains(award.Id))
                    {
                        relations[user.Id].IdOfAwards.Add(award.Id);
                    }
                }
                else
                {
                    relations.Add(user.Id, new Relation(user.Id, new Guid[] { award.Id }));
                }
                _dataCache.PutRelations(relations);
            }
            else
            {
                throw new ArgumentException("Such user or award is not exist!");
            }
            return result;
        }

        public bool ReAward(User user, Award award)
        {
            var users = _dataCache.GetUsers();
            var awards = _dataCache.GetAwards();
            var relations = _dataCache.GetRelations();
            var result = users.ContainsKey(user.Id) && awards.ContainsKey(award.Id);
            if (result)
            {
                if (relations.ContainsKey(user.Id) && relations[user.Id].IdOfAwards.Contains(award.Id))
                {
                    relations[user.Id].IdOfAwards.Remove(award.Id);
                }
                else
                {
                    throw new ArgumentException("This user have not this award!");
                }
                _dataCache.PutRelations(relations);
            }
            else
            {
                throw new ArgumentException("Such user or award is not exist!");
            }
            return result;
        }

        public void SetImage(Guid id, HttpPostedFileBase file) 
        {
            string fileName = PuthToImagesForUsers + id.ToString();
            file.SaveAs(fileName);
        }

        public byte[] GetImage(Guid id)
        {
            string fileName = PuthToImagesForUsers + id.ToString();
            if (File.Exists(fileName))
            {
                return File.ReadAllBytes(fileName);
            }
            return File.ReadAllBytes(PuthToDefaultImageForUsers);
        }

        private void GetAwardsOfUser(User user)
        {
            var relations = _dataCache.GetRelations();
            Relation relation;
            bool result = relations.TryGetValue(user.Id, out relation);
            if (result)
            {
                var awards = _dataCache.GetAwards();
                user.Awards = relation.IdOfAwards.Select(ID => awards[ID]).ToList();
            }
        }


        public bool EditImage(Guid id, HttpPostedFileBase file)
        {
            this.SetImage(id, file);
            return true;
        }
    }
}