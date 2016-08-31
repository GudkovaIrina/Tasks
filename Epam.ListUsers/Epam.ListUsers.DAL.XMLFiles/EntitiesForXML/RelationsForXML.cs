using Epam.ListUsers.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles.EntitiesForXML
{
    [XmlRootAttribute("Data")]
    public class RelationsForXML
    {
        [XmlArrayAttribute("Relations")]
        public RelationForXML[] relations;

        public RelationsForXML()
        {
        }

        public RelationsForXML(IEnumerable<Relation> relations)
        {
            this.relations = relations.Select(r => new RelationForXML(r)).ToArray();
        }
    }
}