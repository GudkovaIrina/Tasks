﻿using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.ListUsers.DAL.XMLFiles
{
    public class AwardsDao
    {
        private DataCache _dataCache;

        public AwardsDao()
        {
            _dataCache = DataCache.Instance;
        }

        public bool Add(Award award)
        {
            var awards = _dataCache.GetAwards();
            bool result = !awards.ContainsKey(award.Id);
            if (result)
            {
                awards.Add(award.Id, award);
                _dataCache.PutAwards(awards);
            }

            return result;
        }

        public Award GetById(Guid id)
        {
            Award award;
            var awards = _dataCache.GetAwards();
            bool result = awards.TryGetValue(id, out award);
            if (result)
            {
                return award;
            }
            throw new ArgumentException("Award with such Id is not exist");
        }

        public List<Award> GetAll()
        {
            return _dataCache.GetAwards().Values.ToList();
        }

        public bool Edit(Award newAward)
        {
            var awards = _dataCache.GetAwards();
            bool result = awards.ContainsKey(newAward.Id);
            if (result)
            {
                awards[newAward.Id].Title = newAward.Title;
                _dataCache.PutAwards(awards);
            }

            return result;
        }

        public bool Remove(Award award)
        {
            var awards = _dataCache.GetAwards();
            bool result = awards.ContainsKey(award.Id);
            if (result)
            {
                awards.Remove(award.Id);
                var relations = _dataCache.GetRelations();
                IEnumerable<Guid> IdUsersWithAward = relations.Values
                                                              .Where(r => r.IdOfAwards.Contains(award.Id))
                                                              .Select(r => r.IdOfUser);
                if (IdUsersWithAward.Count() > 0)
                {
                    foreach (var r in IdUsersWithAward)
                    {
                        relations[r].IdOfAwards.Remove(award.Id);
                    }
                    _dataCache.PutRelations(relations);
                }
                _dataCache.PutAwards(awards);
            }

            return result;
        }

        public List<User> GetAllUsersWithAward(Award award)
        {
            var awards = _dataCache.GetAwards();
            var users = _dataCache.GetUsers();
            var relations = _dataCache.GetRelations();
            var usersWithAward = new List<User>();
            if (awards.ContainsKey(award.Id))
            {
                usersWithAward = relations.Values
                                 .Where(r => r.IdOfAwards.Contains(award.Id))
                                 .Select(r => users[r.IdOfUser])
                                 .ToList();
            }
            else
            {
                throw new ArgumentException("Such award is not exist!");
            }

            return usersWithAward;
        }
    }
}