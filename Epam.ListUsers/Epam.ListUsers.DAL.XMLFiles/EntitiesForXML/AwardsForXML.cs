using Epam.ListUsers.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles
{
    [XmlRootAttribute("Data")]
    public class AwardsForXML
    {
        [XmlArrayAttribute("Awards")]
        public AwardForXML[] awards;

        public AwardsForXML()
        {
        }

        public AwardsForXML(IEnumerable<Award> awards)
        {
            this.awards = awards.Select(a => new AwardForXML(a)).ToArray();
        }
    }
}