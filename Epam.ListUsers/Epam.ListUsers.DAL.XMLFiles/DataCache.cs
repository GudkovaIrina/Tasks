using Epam.ListUsers.DAL.XMLFiles.EntitiesForXML;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Epam.ListUsers.DAL.XMLFiles
{
    public class DataCache  //Может тут лучше internal?
    {
        private static DataCache instance;

        private string NameDataFileForUsers = ConfigurationManager.AppSettings["PathForUsers"];
        private string NameDataFileForRelations = ConfigurationManager.AppSettings["PathForRelations"];
        private string NameDataFileForAwards = ConfigurationManager.AppSettings["PathForAwards"];

        private Dictionary<Guid, User> _users;
        private Dictionary<Guid, Award> _awards;
        private Dictionary<Guid, Relation> _relations;

        private DataCache()
        {
            InitData<User>(NameDataFileForUsers, ref _users, GetUsers);
            InitData<Award>(NameDataFileForAwards, ref _awards, GetAwards);
            InitData<Relation>(NameDataFileForRelations, ref _relations, GetRelations);
        }

        public static DataCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataCache();
                }
                return instance;
            }
        }

        public Dictionary<Guid, User> GetUsers()
        {
            _users = ControlRelevanceOfData<UsersForXML, User>
                                       (NameDataFileForUsers,
                                       _users,
                                       usersForXML => usersForXML.users
                                              .Select(u => new User(u.Name, u.DateOfBirth) { Id = u.Id })
                                              .ToDictionary(u => u.Id));
            return _users;
        }

        public void PutUsers(IDictionary<Guid, User> users)
        {
            SerializeTo<UsersForXML, User>(NameDataFileForUsers,
                                                     users,
                                                     u => new UsersForXML(u));
        }

        public Dictionary<Guid, Award> GetAwards()
        {
            _awards = ControlRelevanceOfData<AwardsForXML, Award>
                                       (NameDataFileForAwards,
                                       _awards,
                                       awardsForXML => awardsForXML.awards
                                                                 .Select(a => new Award(a.Title) { Id = a.Id })
                                                                 .ToDictionary(a => a.Id));
            return _awards;
        }

        public void PutAwards(IDictionary<Guid, Award> awards)
        {
            SerializeTo<AwardsForXML, Award>(NameDataFileForAwards,
                                                     awards,
                                                     a => new AwardsForXML(a));
        }

        public Dictionary<Guid, Relation> GetRelations()
        {
            _relations = ControlRelevanceOfData<RelationsForXML, Relation>
                                        (NameDataFileForRelations,
                                        _relations,
                                        relationsForXML => relationsForXML.relations
                                            .Select(r => new Relation(r.IdOfUser, r.IdOfAwards))
                                            .ToDictionary(r => r.IdOfUser));

            return _relations;
        }

        public void PutRelations(IDictionary<Guid, Relation> relations)
        {
            SerializeTo<RelationsForXML, Relation>(NameDataFileForRelations,
                                                relations,
                                                r => new RelationsForXML(r));
        }

        private void SerializeTo<T, TItem>(string NameFileTo, IDictionary<Guid, TItem> collection, Func<IEnumerable<TItem>, T> func)
        {
            T collectionForXML = func(collection.Values);
            Serializer<T>.SerializeTo(NameFileTo, collectionForXML);
        }

        private Dictionary<Guid, TItem> ControlRelevanceOfData<T, TItem>(string NameFileOut, Dictionary<Guid, TItem> collection, Func<T, Dictionary<Guid, TItem>> func) where T : new()
        {
            if (File.GetLastWriteTime(NameFileOut) > Serializer<T>.TimeOfLastDeserialization && File.Exists(NameFileOut))
            {
                T collectionForXML = new T();
                Serializer<T>.DeserializeTo(NameFileOut, ref collectionForXML);
                return func(collectionForXML);
            }
            else
            {
                return collection;
            }
        }

        private void InitData<T>(string nameFile, ref Dictionary<Guid, T> collection, Func<Dictionary<Guid, T>> func)
        {
            collection = new Dictionary<Guid, T>();
            if (File.Exists(nameFile))
            {
                collection = func();
            }
        }
    }
}