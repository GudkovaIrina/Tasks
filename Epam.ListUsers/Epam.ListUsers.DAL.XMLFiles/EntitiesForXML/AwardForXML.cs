using Epam.ListUsers.Entities;
using System;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles
{
    public class AwardForXML
    {
        [XmlElementAttribute("Id")]
        public Guid Id { get; set; }

        [XmlElementAttribute("Title")]
        public string Title { get; set; }

        public AwardForXML()
        {
        }

        public AwardForXML(Award award)
        {
            this.Id = award.Id;
            this.Title = award.Title;
        }
    }
}