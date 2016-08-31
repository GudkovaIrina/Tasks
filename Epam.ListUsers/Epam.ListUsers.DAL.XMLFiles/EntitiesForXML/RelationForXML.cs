using Epam.ListUsers.Entities;
using System;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles.EntitiesForXML
{
    public class RelationForXML
    {
        [XmlElementAttribute("IdOfUser")]
        public Guid IdOfUser { get; set; }

        [XmlArrayAttribute("IdAwardsOfUser")]
        public Guid[] IdOfAwards;

        public RelationForXML()
        {
        }

        public RelationForXML(Relation relation)
        {
            this.IdOfUser = relation.IdOfUser;
            this.IdOfAwards = relation.IdOfAwards.ToArray();
        }
    }
}